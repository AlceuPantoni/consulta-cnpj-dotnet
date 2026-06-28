using ConsultaCnpj.Models;
using ConsultaCnpj.Services;

public class CnpjProcessingController
{
    private readonly ExcelService _excel;
    private readonly CnpjService _cnpjService;
    private CancellationTokenSource? _cts;
    public List<string> Cnpjs { get; private set; } = new();
    public List<ConsultaResultado> Resultados { get; private set; } = new();
    public event Action<int, int>? Progresso;
    public event Action<string>? Log;
    public bool Cancelado { get; private set; }

    public CnpjProcessingController(ExcelService excel, CnpjService cnpjService)
    {
        _excel = excel;
        _cnpjService = cnpjService;
        Cancelado = false;
    }

    public void CarregarArquivo(string path)
    {
        try
        {
            Cnpjs = _excel.LerCnpjs(path);
            RegistrarLog($"Planilha válida carregada - Total de {Cnpjs.Count} CNPJs");
        }
        catch (Exception ex)
        {
            RegistrarLog(ex.Message);
            throw;
        }
    }

    public async Task ExecutarConsultaAsync()
    {
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        Cancelado = false;
        Resultados.Clear();

        int total = Cnpjs.Count;
        int atual = 0;
        string cnpjAtual = string.Empty;

        TimeSpan tempoEstimado = TimeSpan.FromSeconds((total - 1) * 25 + total * 2);

        RegistrarLog($"Iniciando consulta de {total} CNPJs. Tempo estimado: {FormatarTempo(tempoEstimado)}.");

        try
        {
            foreach (var cnpj in Cnpjs)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                cnpjAtual = cnpj;

                var result = await _cnpjService.ConsultarAsync(cnpj);
                
                RegistrarLog($"CNPJ {atual + 1} de {total} consultado com sucesso");
                
                if(result.Resultado == "OK")
                {
                    RegistrarLog($"Resultado: {result.Resultado} | Empresa: {result.Empresa?.Nome}");
                }
                else
                {
                    RegistrarLog($"Resultado: {result.Resultado} | Motivo: {result.Erro}");
                }
                
                Resultados.Add(result);

                atual++;

                Progresso?.Invoke(atual, total);

                if (atual < total)
                {
                    RegistrarLog("Aguardando intervalo da API para próxima consulta (+- 25 seg.)");
                    await Task.Delay(TimeSpan.FromSeconds(25), token);
                }
                    
            }

            RegistrarLog("Consultas finalizadas");
            RegistrarLog("Clique em Salvar Resultado para gerar planilha com os dados");
        }
        catch (Exception ex)
        {
            RegistrarLog($"Erro ao obter dados do cnpj {cnpjAtual}");
            RegistrarLog($"Mensagem de erro: {ex.Message}");
        }
    }

    public void Cancelar()
    {
        _cts?.Cancel();

        Cnpjs.Clear();
        Cancelado = true;
        
        RegistrarLog("Processamento cancelado");
        
        if (Resultados.Count > 0)
        {
            RegistrarLog($"Há resultado para {Resultados.Count} CNPJs. Para salvar, clique em Salvar Resultado");
        }
    }

    public void Exportar(string path)
    {
        try
        {
            _excel.ExportarResultados(Resultados, path);
            RegistrarLog($"Planilha de resultado gerada com sucesso contendo {Resultados.Count} registros.");
            RegistrarLog($"Arquivo gravado em {path}");
        }
        catch (Exception ex)
        {
            RegistrarLog($"Erro ao gerar planilha {ex.Message}");
            throw;
        }
        
    }

    public void Limpar()
    {
        Cnpjs.Clear();
        Resultados.Clear();
    }

    private void RegistrarLog(string mensagem)
    {
        string mensagemAjustada = $"[{DateTime.Now:HH:mm:ss}]  {mensagem}";
        Log?.Invoke(mensagemAjustada);
    }

    private static string FormatarTempo(TimeSpan tempo)
    {
        if (tempo.TotalMinutes < 1)
            return $"{tempo.Seconds} segundos";

        if (tempo.TotalHours < 1)
            return $"{tempo.Minutes} minuto{(tempo.Minutes > 1 ? "s" : "")} e {tempo.Seconds} segundo{(tempo.Seconds != 1 ? "s" : "")}";

        return $"{(int)tempo.TotalHours} hora{((int)tempo.TotalHours > 1 ? "s" : "")}, {tempo.Minutes} minuto{(tempo.Minutes != 1 ? "s" : "")} e {tempo.Seconds} segundo{(tempo.Seconds != 1 ? "s" : "")}";
    }
}