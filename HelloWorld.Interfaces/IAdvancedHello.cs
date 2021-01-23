using System.Threading.Tasks;

namespace HelloWorld.Interfaces
{
    public interface IHelloB : Orleans.IGrainWithStringKey
    {
        Task<string> SayHello(string greeting);
    }
}