namespace jimu
{
    class Program
    {
        static HttpClient client = new HttpClient();

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
            Console.WriteLine("Hello World!");

            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                string url = "https://api.cryptowat.ch/markets/bybit/BTCUSDT/ohlc?after=1667239230";
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
