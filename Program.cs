using System.Text.Json;

namespace jimu
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static long GenerateUnixTime()
        {
            DateTimeOffset dto = new DateTimeOffset(2022, 10, 1, 15, 30, 0, 0, TimeSpan.Zero);
            return dto.ToUnixTimeSeconds();
        }

        static string GeneratePath(long unixTime)
        {
            // e.g. https://api.cryptowat.ch/markets/:exchange/:pair/ohlc
            string exchange = "bybit";
            string pair = "BTCUSDT";
            string min = "60";
            return $"https://api.cryptowat.ch/markets/{exchange}/{pair}/ohlc?periods={min}&after={unixTime}";
        }

        static async Task<string> GetJsonAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //File.WriteAllText($"{requestTime}.json", json);
                return json;
            }

            return string.Empty;
        }

        //static async Task<>

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                var list = new CandleStickData();
                list.Candlesticks = new List<List<double>>();

                for (int i = 0; i < 3; i++)
                {
                    const int ADD_SECOUNDS = 30000;
                    long unixTime = GenerateUnixTime();
                    long requestTime = unixTime + (i * ADD_SECOUNDS);
                    string url = GeneratePath(requestTime);
                    string json = await GetJsonAsync(url);

                    var result = JsonSerializer.Deserialize<CandleStickRootModel>(json);
                    var candleSticks = result?.CandleStickData.Candlesticks;

                    if (candleSticks != null)
                    {
                        list.Candlesticks.AddRange(candleSticks);
                    }
                }

                string jsonString = JsonSerializer.Serialize(list);
                File.WriteAllText("candle.json", jsonString);

                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(@$"{e.Message},
                                {Environment.NewLine}
                                {e.StackTrace}");
            }

            Console.ReadLine();
        }

    }
}
