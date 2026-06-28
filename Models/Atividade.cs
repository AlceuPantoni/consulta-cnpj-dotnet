using System.Text.Json.Serialization;

namespace ConsultaCnpj.Models
{
    public class Atividade
    {
        [JsonPropertyName("code")]
        public string? Codigo { get; set; }

        [JsonPropertyName("text")]
        public string? Descricao { get; set; }
    }
}
