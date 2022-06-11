using System.Text.Json.Serialization;

namespace SpeedControl.API.Domain
{
    public class PenaltysBatch
    {
        [JsonPropertyName("matricula")]
        public string LicensePlate { get; set; } = string.Empty;
        public Penaltys Info { get; set; } = new Penaltys();
    }
}
