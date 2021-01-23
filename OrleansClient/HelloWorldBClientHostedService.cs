using System;
using System.Threading;
using System.Threading.Tasks;

using HelloWorld.Interfaces;

using Microsoft.Extensions.Hosting;

using Orleans;

namespace OrleansClient
{
    public class HelloWorldBClientHostedService : IHostedService
    {
        private readonly IClusterClient _client;

        public HelloWorldBClientHostedService(IClusterClient client)
        {
            this._client = client;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // example of calling grains from the initialized client
            var randomName = Program.CreateString();
            var friend = this._client.GetGrain<IHelloB>(randomName);
            var response = await friend.SayHello($"Good morning, {randomName}");
            Console.WriteLine($"{response}");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}