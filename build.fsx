// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake
open System
open Fake.AssemblyInfoFile

RestorePackages()

let version = "0.1.0-pre"
let projectName = "HelloNuget"
let buildMode = getBuildParamOrDefault "buildMode" "Release"
let packagesDir = "./packages/"
let packageStagingRootDir = "./temp/package-staging/"
let projectBin = "src" @@ projectName @@ "bin"

Target "Clean" (fun _->
    [packageStagingRootDir; projectBin] |> CleanDirs
)

Target "BuildApp" (fun _-> 
   MSBuild null "Build" ["Configuration", buildMode] ["./HelloNuget.sln"] |> Log "AppBuild-Output: "
)

Target "CreatePackage" (fun _ -> 
    let projectPackageWorkingDir = packageStagingRootDir @@ projectName
    let platformLibStagingDir =projectPackageWorkingDir  @@ "lib/net45"
    CleanDir platformLibStagingDir
    CopyFile platformLibStagingDir  ("./src" @@ projectName @@ "bin" @@ buildMode @@ projectName + ".dll" ) 
    CopyFiles projectPackageWorkingDir ["README.md"; "LICENSE.txt"] 

    NuGet(fun p -> 
        {p with 
            Project =projectName 
            Authors = ["Craig Smitham"]
            Description = "A minimal example for creating a .NET open source project with a build configuration and automated package creation" 
            OutputPath = "./temp/package-output"
            Summary = "" 
            WorkingDir = projectPackageWorkingDir
            Version = version 
            Tags = "nuget fake" 
            PublishUrl = "C:\NuGetPackages" 
            AccessKey = "" 
            Publish = true }) "./template.nuspec"
)

Target "Default" DoNothing

// This syntax specifies the build dependencies
"Clean"
    ==> "BuildApp"
        ==> "CreatePackage"

// Start the build
RunTargetOrDefault "Default"