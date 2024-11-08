namespace HttpJsonApp;

class Program
{
    static void Main(string[] args)
    {
        DataFetcher fileFetcher = new DataFetcher(new HttpClient());
        fileFetcher.Fetch().Wait();
    }
}
