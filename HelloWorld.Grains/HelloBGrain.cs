using HelloWorld.Interfaces;
using System.Threading.Tasks;
using Orleans;

namespace HelloWorld.Grains
{
    public class HelloBGrain : Orleans.Grain, IHelloB
    {
        public async Task<string> SayHello(string greeting)
        {
            return await Task.FromResult($"Hello {greeting} ");
        }
    }
}