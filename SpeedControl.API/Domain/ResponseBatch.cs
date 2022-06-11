using System.Text.Json.Serialization;

namespace SpeedControl.API.Domain
{
    public class ResponseBatch
    {
        [JsonPropertyName("multasValidas")]
        public IEnumerable<PenaltysBatch> penaltysBatchValid { get; set; } =    new List<PenaltysBatch>();

        [JsonPropertyName("multasInvalidas")]
        public IEnumerable<PenaltysBatch> PenaltysBatchNotValid { get; set; } = new List<PenaltysBatch>();
    }
}
