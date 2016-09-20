# Nice.Build

**Nice.Build** is a set of MSBuild extensions to ease the .NET development process by using *convention over configuration*.


## Usage

Import the `Nice.ProjectDefaults.props` file **at the top** of your `.csproj` (or any other .NET project) file:

```
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003" ...>
	<Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" ... />
	<Import Project="$(MSBuildExtensionsPath)\Nice\Nice.ProjectDefaults.props" Condition="Exists('$(MSBuildExtensionsPath)\Nice\Nice.ProjectDefaults.props')"/>
	...
```

> Notice that `Nice.ProjectDefaults.props` should come **after** the `Microsoft.Common.props`. If your project imports any other files like this you might have to experiment with the exact order to make everything work as expected.

The second part is to import the `Nice.Build.targets` file **at the bottom** of your project file:

```
	...
	<Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" .../>
	<Import Project="$(MSBuildExtensionsPath)\Nice\Nice.Build.targets" Condition="Exists('$(MSBuildExtensionsPath)\Nice\Nice.Build.targets')"/>
</Project>
```

All "Nice" imports are conditional, nothing should happen if any of those files is missing, i.e. your project will not fail to build.
This is true only if you do not reference directly any custom properties and/or targets (from those files) in your projects, in which case the build should fail if those files are missing.


## How To Build or Contribute

This project doesn't actually build anything, it is supposed to **deploy** the (MS)build customization files (i.e. MSBuild properties and targets) to the *MSBuild Extensions* folder, usually located at `C:\Program Files (x86)\MSBuild`.

To deploy the customizations simply issue the following command from the project root folder (e.g. `D:\dotnet-dev\Nice.Framework\Nice.Build`):

```
D:\dotnet-dev\Nice.Framework\Nice.Build> msbuild
```

The command lets MSBuild automatically locate the `Nice.Build.proj` file and execute its default target, but if you want to be specific you can use the full command:

```
D:\dotnet-dev\Nice.Framework\Nice.Build> msbuild Nice.Build.proj /target:Deploy
```

> Since writing to `C:\Program Files (x86)` is usually restricted, developers wanting to contribute to this project can simulate deployment into the local `build` folder by using the following command:
```
D:\dotnet-dev\Nice.Framework\Nice.Build> msbuild Nice.Build.proj /target:Deploy /p:Simulation=true
```

Any *unit tests*  (in the form of MSBuild projects) can be found inside the `Test` folder, and run with the following command:

```
D:\dotnet-dev\Nice.Framework\Nice.Build> msbuild Nice.Build.proj /target:Test
```
