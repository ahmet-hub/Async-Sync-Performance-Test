namespace Client
{
    public class HttpService
    {
        private const string URL = "https://localhost:5001/api/Home/";

        public async Task GetAsync(string path)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(URL) };
            var response = await client.GetAsync(path);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
