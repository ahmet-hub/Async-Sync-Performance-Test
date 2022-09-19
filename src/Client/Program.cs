

using Client;
using System.Diagnostics;

do
{
    Console.Write("Request Type (Sync = 0 , Async = 1) : ");

    int requestType = int.Parse(Console.ReadLine());

    Console.Write("Request Count : ");

    int requestCount = int.Parse(Console.ReadLine());

    var path = requestType switch
    {
        0 => "Sync",
        1 => "Async",
        _ => throw new NotImplementedException()
    };

    var sw = Stopwatch.StartNew();
    var tasks = SendHtttpSequestAsync(requestCount, path);
    await Task.WhenAll(tasks);

    sw.Stop();
    AddLog($"Total Time : {sw.ElapsedMilliseconds} MS");

} while (Console.ReadKey().Key == ConsoleKey.R);



static IEnumerable<Task> SendHtttpSequestAsync(int count, string path)
{
    var result = new List<Task>();
    HttpService httpService = new HttpService();

    for (int i = 0; i < count; i++)
        result.Add(httpService.GetAsync(path));

    return result;
}

static void AddLog(string logStr)
{
    logStr = $"[{DateTime.Now:dd.MM.yyy HH:mm:ss}] - {logStr}";
    Console.WriteLine(logStr);
}