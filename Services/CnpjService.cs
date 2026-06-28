using System.Text.Json;
using ConsultaCnpj.Models;

namespace ConsultaCnpj.Services;

public class CnpjService
{
    private const string UrlBase = "https://receitaws.com.br/v1/cnpj/";
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(60);

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _httpClient;

    public CnpjService()
    {
        _httpClient = new HttpClient{Timeout = Timeout};

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ConsultaCnpj");
    }

    public async Task<ConsultaResultado> ConsultarAsync(string cnpj)
    {
        Empresa e = new() { Cnpj = cnpj };

        string cnpjAjustado = LimparCnpj(cnpj);

        try
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                return new ConsultaResultado
                {
                    Resultado = "ERRO",
                    Erro = "Cnpj não informado.",
                    Empresa = e
                };
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{UrlBase}{cnpjAjustado}");

            if (!response.IsSuccessStatusCode)
            {
                return new ConsultaResultado
                {
                    Resultado = "ERRO",
                    Erro = $"Erro HTTP {(int)response.StatusCode} - {response.ReasonPhrase ?? "Sem descrição"}",
                    Empresa = e
                };
            }

            string json = await response.Content.ReadAsStringAsync();

            Empresa? empresa = JsonSerializer.Deserialize<Empresa>(json, JsonOptions);

            if (empresa is null)
            {
                return new ConsultaResultado
                {
                    Resultado = "ERRO",
                    Erro = "Não foi possível interpretar a resposta da API.",
                    Empresa = e
                };
            }

            if (empresa.Status?.Equals("ERROR", StringComparison.OrdinalIgnoreCase) == true)
            {
                empresa.Cnpj = cnpj;
                
                return new ConsultaResultado
                {
                    Resultado = "ERRO",
                    Erro = "O CNPJ informado não foi encontrado.",
                    Empresa = empresa
                };
            }

            return new ConsultaResultado
            {
                Resultado = "OK",
                Empresa = empresa
            };
        }
        catch (Exception ex)
        {
            return new ConsultaResultado
            {
                Resultado = "ERRO",
                Erro = ex.Message,
                Empresa = e
            };
        }
    }

    private static string LimparCnpj(string cnpj)
    {
        return new string(cnpj.Where(char.IsDigit).ToArray());
    }
}