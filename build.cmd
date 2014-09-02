@echo off

: Ensure FAKE is installed
"tools\nuget.exe" "Install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion"
cls

: Build

: Get build target from first parameter or set default
IF [%1]==[] (set TARGET="BuildApp") ELSE (set TARGET="%1")

: Get build mode from second parameter or set default
IF [%2]==[] (set BUILDMODE="Release") ELSE (set BUILDMODE="%2")

"packages\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%" "buildMode=%BUILDMODE%"

: Quit
exit /b %errorlevel%