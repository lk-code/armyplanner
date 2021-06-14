using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace ArmyPlanner.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new ArmyPlanner.App(), args);
            host.Run();
        }
    }
}
