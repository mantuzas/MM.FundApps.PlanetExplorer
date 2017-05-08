
dotnet restore

dotnet test ./MM.FundApps.PlanetExplorer.Robot.Tests/MM.FundApps.PlanetExplorer.Robot.Tests.csproj -c Release

dotnet build -c Release

#   git update-index --chmod=+x build.sh