namespace jimu
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static long GenerateUnixTime()
        {
            DateTimeOffset dto = new DateTimeOffset(2022, 11, 1, 15, 30, 0, TimeSpan.Zero);
            return dto.ToUnixTimeSeconds();
        }

        static string GeneratePath(long unixTime)
        {
            // e.g. https://api.cryptowat.ch/markets/:exchange/:pair/ohlc
            string exchange = "bybit";
            string pair = "BTCUSDT";
            return $"https://api.cryptowat.ch/markets/{exchange}/{pair}/ohlc?after={unixTime}";
        }

        static async Task GetProductAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                File.WriteAllText("candle.json", json);
            }
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                long unixTime = GenerateUnixTime();
                string url = GeneratePath(unixTime);
                await GetProductAsync(url);
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
