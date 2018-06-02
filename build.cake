var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var cleanTask = Task("Clean")
    .Does(() =>
{
    Information("Cleaning solution");
    DotNetCoreClean("./src");
});

var nugetTask = Task("NuGetRestorePackages")
    .IsDependentOn(cleanTask)
    .Does(() =>
{
    Information("Restoring Nuget packages for solution");
    DotNetCoreRestore("./src/src.sln");
});

var buildTask = Task("BuildSolution")
    .IsDependentOn(nugetTask)
    .Does(() =>
{
    Information("Building solution");
    DotNetCoreBuild(
        "./src/src.sln",
        new DotNetCoreBuildSettings()
        {
            Configuration = configuration,
            NoRestore = true
        });
});

var unitTestsTask = Task("RunUnitTests")
    .IsDependentOn(buildTask)
    .Does(() =>
{
    Information("Running xunit tests");

    DotNetCoreTest(
        "./src/BggCoreSdk.UnitTests/BggCoreSdk.UnitTests.csproj",   
        new DotNetCoreTestSettings()
        {
            Configuration = configuration,
            NoBuild = true
        });
});

Task("Default")
    .IsDependentOn(unitTestsTask);

RunTarget(target);