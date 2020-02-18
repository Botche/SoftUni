using System.Threading.Tasks;

using SIS.MvcFramework;

namespace SULS.App
{
    public class Program
    {
        public async static Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}