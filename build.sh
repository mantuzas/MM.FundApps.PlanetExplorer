
dotnet restore

dotnet test ./MM.FundApps.PlanetExplorer.RemoteControlCenter.Tests/MM.FundApps.PlanetExplorer.RemoteControlCenter.Tests.csproj -c Release
dotnet test ./MM.FundApps.PlanetExplorer.Robot.Abstractions.Tests/MM.FundApps.PlanetExplorer.Robot.Abstractions.Tests.csproj -c Release
dotnet test ./MM.FundApps.PlanetExplorer.Robot.Tests/MM.FundApps.PlanetExplorer.Robot.Tests.csproj -c Release

dotnet build -c Release

#   git update-index --chmod=+x build.sh