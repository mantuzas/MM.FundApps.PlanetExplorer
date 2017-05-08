using System;

namespace MM.FundApps.PlanetExplorer.RemoteControlCenter.Abstractions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(char command)
        {
            Command = command;
        }

        public char Command { get; }
    }
}