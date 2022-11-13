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
            return $"https://api.cryptowat.ch/markets/{exchange}/{pair}/ohlc?after={unixTime}";
        }

        static async Task GetProductAsync(string path, long requestTime)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                File.WriteAllText($"{requestTime}.json", json);
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
                for (int i = 0; i < 3; i++)
                {
                    const int ADD_SECOUNDS = 30000;
                    long unixTime = GenerateUnixTime();
                    long requestTime = unixTime + (i * ADD_SECOUNDS);
                    string url = GeneratePath(requestTime);
                    await GetProductAsync(url, requestTime);
                }

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
