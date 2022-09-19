using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Sync")]
        public IActionResult Sync()
        {
            Thread.Sleep(2000);
            
            ThreadPool.GetAvailableThreads(out int workerThreads, out int threads);
            return Ok(new Response { WorkerThreads = workerThreads, Threads = threads, CurrentThreadId = Thread.CurrentThread.ManagedThreadId });
        }

        [HttpGet]
        [Route("Async")]
        public async Task<IActionResult> Async()
        {
            await Task.Delay(2000);

            ThreadPool.GetAvailableThreads(out int workerThreads, out int threads);
            return Ok(new Response { WorkerThreads = workerThreads, Threads = threads, CurrentThreadId = Thread.CurrentThread.ManagedThreadId });
        }
    }
}
