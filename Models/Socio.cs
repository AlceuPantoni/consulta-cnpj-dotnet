using System.Text.Json.Serialization;

namespace ConsultaCnpj.Models
{
    public class Socio
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("qual")]
        public string? Qualificacao { get; set; }
    }
}
