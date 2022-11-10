namespace jimu
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static string GeneratePath()
        {
            // e.g. https://api.cryptowat.ch/markets/:exchange/:pair/ohlc
            string exchange = "bybit";
            string pair = "BTCUSDT";
            string url = $"https://api.cryptowat.ch/markets/{exchange}/{pair}/ohlc?after=1667239230";

            return url;
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
                string url = GeneratePath();
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
