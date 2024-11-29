#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-Android");

Task("Clean-Artifacts")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"./Build/artifacts");
});

Task("Build-Android")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    UnityEditor(
        2022, 3,
        new UnityEditorArguments
        {
            ExecuteMethod="Editor.Builder.BuildAndroid",
            BuildTarget=BuildTarget.Android,
            LogFile = "./Build/artifacts/unity.log",
            ProjectPath = "./",
        },
        new UnityEditorSettings
        {
            RealTimeLog = true,
        });
});


RunTarget(target);
