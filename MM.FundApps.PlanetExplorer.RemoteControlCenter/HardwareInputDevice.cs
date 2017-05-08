using System;
using MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter
{
    public class HardwareInputDevice : IHardwareInputDevice
    {
        // ncrunch: no coverage start
        public string Capture()
        {
            return Console.ReadLine();
        }
        // ncrunch: no coverage end
    }
}