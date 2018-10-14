#tool "nuget:?package=OpenCover"
#tool nuget:?package=Codecov
#addin nuget:?package=Cake.Codecov

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
            NoRestore = true,
            ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
        });
});

var unitTestsTask = Task("RunUnitTests")
    .IsDependentOn(buildTask)
    .Does(() =>
{
    Information("Running xunit tests");

    OpenCover(tool => {
        tool.DotNetCoreTest(
            "./src/BggCoreSdk.UnitTests/BggCoreSdk.UnitTests.csproj",   
            new DotNetCoreTestSettings()
            {
                Configuration = configuration,
                NoBuild = true
            });
        },
        new FilePath("./OpenCoverResults.xml"),
        new OpenCoverSettings() 
        { 
            SkipAutoProps = true,
            Register = "user",
            OldStyle = true 
        }
        .WithFilter("+[BggCoreSdk]*")
        .WithFilter("-[BggCoreSdk.UnitTests]*"));

    Codecov("./OpenCoverResults.xml", "f7c9d882-99e0-4a44-a651-16ed7cee7bc4");
});

Task("Default")
    .IsDependentOn(unitTestsTask);

RunTarget(target);