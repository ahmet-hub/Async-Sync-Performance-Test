namespace Api.Controllers
{
    internal class Response
    {
        public int WorkerThreads { get; set; }
        public int Threads { get; set; }
        public int CurrentThreadId{ get; set; }
    }
}