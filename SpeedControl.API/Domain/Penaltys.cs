using System.Text.Json.Serialization;

namespace SpeedControl.API.Domain
{
    public class Penaltys
    {
        [JsonPropertyName("distance")]
        public string Distance { get; set; } = string.Empty;

        [JsonPropertyName("multa")]
        public string Penalty { get; set; } = string.Empty;

        [JsonPropertyName("ciudadAsignada")]
        public string AssignedCity { get; set; } = string.Empty;
        
        [JsonIgnore]
        public bool isValidPenalty { get; set; } = false;

    }
}
