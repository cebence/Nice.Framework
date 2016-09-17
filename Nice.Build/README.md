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

No need to worry that your project will fail to build if `Nice.ProjectDefaults.props` is missing - the `Condition` prevents that from happening.

**TODO Part 2, import the targets.**


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
