namespace ConsultaCnpj.Models;

public class ConsultaResultado
{
    public string Resultado { get; set; } = string.Empty;

    public string? Erro { get; set; }

    public Empresa? Empresa { get; set; }
}