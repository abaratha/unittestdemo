dotnet-sonarscanner begin /o:"abaratha" /k:"abaratha_unittestdemo"  /d:sonar.host.url="https://sonarcloud.io"  /d:sonar.login="fc0d2ee248638d9207b9a7b861e8e97d09f8f092" 
dotnet build UnitTestDemo\UnitTestDemo.csproj
dotnet-sonarscanner end /d:sonar.login="fc0d2ee248638d9207b9a7b861e8e97d09f8f092" 