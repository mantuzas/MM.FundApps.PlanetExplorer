using System;
using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter
{
    public class HardwareOutputDevice : IHardwareOutputDevice
    {
        // ncrunch: no coverage start
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
        // ncrunch: no coverage end
    }
}