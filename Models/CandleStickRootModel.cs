using System.Text.Json.Serialization;

namespace jimu
{
    public class CandleStickRootModel
    {
        [JsonPropertyName("result")]
        public CandleStickData CandleStickData { get; set; }
    }
}
