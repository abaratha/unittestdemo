dotnet-sonarscanner begin /o:"abaratha" /k:"abaratha_unittestdemo"  /d:sonar.host.url="https://sonarcloud.io"  /d:sonar.login="fc0d2ee248638d9207b9a7b861e8e97d09f8f092"  /d:sonar.coverageReportPaths=".\sonarqubecoverage\SonarQube.xml"
dotnet build UnitTestDemo.sln
dotnet test --no-build --collect:"XPlat Code Coverage" API.Tests\API.Tests.csproj
reportgenerator "-reports:*\TestResults\*\coverage.cobertura.xml" "-targetdir:sonarqubecoverage" "-reporttypes:SonarQube"
dotnet-sonarscanner end /d:sonar.login="fc0d2ee248638d9207b9a7b861e8e97d09f8f092" 