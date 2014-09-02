# Overview

This project provides a minimal example for how to set up a .NET project 
for automatic packaging with NuGet. 

Once you get the basics down, you will likely make some tweaks to streamline your workflow. Use these examples to help
streamline and evolve your project to meet your needs:

* [HtmlTags.AspNet.Mvc](http://fsharp.github.io/FAKE/gettingstarted.html) - this project has a build script which takes advantage of some basic features of F# to manage the building and packaging of multiple projects, along with more nuanced configuration that you may find helpful.
* [Ocktokit](https://github.com/octokit/octokit.net) - This project has good examples for integrating testing and multi-platform targeting

It is also a good idea to familiarize yourself with the tools used here, namely NuGet.exe, FAKE, and Git.

# Feedback

Feedback on this solution is welcome. Tweet me [@craigsmitham](https://twitter.com/craigsmitham) or create a GitHub issue.

# Contents

* Prerequisates
* .NET Solution Conventions 
* Learning and Next Steps

## Prerequisates

### Git
Install Git for Windows. Install with the reccomended options, including using Git from the Windows Command Prompt. 
If you're not familiar with Git, I highly reccomend becoming proficient.

### Visual Studio
This guide assumes you will be developing with Visual Studio.

## .NET Solution Conventions

### build.cmd
A simple batch file name 'build.cmd', located in the solution root, acts as a wrapper around the build system. 
As long as all prerequrisates are installed, running this command should execute the build in one step. 
This script can also be used to simplify the execution of common build commands, such as
compiling, testing, and package creation.

### `src/` Directory
All source files live in the `./src` directory. There is a growing trend to put the Visual Studio solution (`.sln`) file in the repositories root directory.
I like this, as it is a more natural fit with the build and solution level items, and the source code is not dependant on the solution file to run.

### `tools/` Directory

Any tools used as part of the build or needed for development can be placed in the tools directory. 
The tools can be placed here by a build script, or checked in to the repository. 

### `tools/NuGet.exe`
I usually check-in NuGet.exe to the tools directory, because it is small and rarely changes.
The latest NuGet.exe can be downloaded from [nuget.org](http://nuget.org) at [http://nuget.org/nuget.exe](http://nuget.org/nuget.exe).

### `.gitignore`
All projects using Git for source control should have a .gitignore file, which intstructs Git to ignore certain file types and directories within your project. 
.gitignore files are usually environment and platform specific, depending on your tools. 

### Build Tool
We will be using [FAKE](http://fsharp.github.io/FAKE/) as a build tool to manage and automate tasks around compiling, testing, and packaging our project with NuGet. If you're not familiar with build tools, that's OK. 
There are other alternatives, including NAnt, PSake, and MSBuild. Visual Studio uses MSBuild directly, as do the other build tools, but these build tools allow for more flexible and accesible project configuration and setup in combination with MSBuild.

* [Exploring FAKE, an F# Build System for all of .NET](http://www.hanselman.com/blog/ExploringFAKEAnFBuildSystemForAllOfNET.aspx) - Scott Hanselman, hanselman.com
* [Getting started with FAKE](http://fsharp.github.io/FAKE/gettingstarted.html) - fsharp.github.io

### License 
Always include a license and copyright notice with your project.

### README
Your project should contain a readme to get new users up to speed.

## Learning and Next Steps

* Create your own project with a build script capable of automatic package creation

* Publish your package to a NuGet feed, such as http://myget.org or http://nuget.org. Start with myget.org to get 
the hang of publishing packages, but use nuget.org once you have a package ready for distribution.

* Integrate your project with an automated build CI, such as AppVeyor.com, publishing your new commits to a NuGet feed.

