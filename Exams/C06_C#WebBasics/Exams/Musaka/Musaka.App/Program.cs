using System.Threading.Tasks;

using SIS.MvcFramework;

namespace Musaka.App
{
    public class Program
    {
        public async static Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}