dotnet test --collect:"XPlat Code Coverage"
dotnet reportgenerator \
    "-reports:DemoBookStore.Domain.UnitTests/TestResults/*/coverage.cobertura.xml" \
    "-targetdir:coveragereport" \
    -reporttypes:Html
