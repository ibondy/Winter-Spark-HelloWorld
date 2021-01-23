using HelloWorld.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Grains
{
    /// <summary>
    /// Orleans grain implementation class HelloGrain.
    /// </summary>
    public class HelloGrain : Orleans.Grain, IHello
    {
        private readonly ILogger _logger;
        private int _counter;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            _logger = logger;
        }

        async Task<string> IHello.SayHello(string greeting)
        {
            _counter++;
            _logger.LogInformation($"SayHello message received: greeting = '{greeting}' ");
            return await Task.FromResult($"You said: '{greeting}', I say: Hello! You are caller:{_counter}");
        }
    }
}