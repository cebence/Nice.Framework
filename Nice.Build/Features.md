# Nice.Build Features

### Automatically detect & mark a unit tests project
If the developer forgets to create the new unit tests project using the correct Visual Studio template (*New* → *Project...* → *Visual C#* → *Test* → *Unit Test Project*) this feature will allow Visual Studio to recognize the project as such - as long as the project's name ends in one of these predefined suffixes:
- `.UnitTests` or `.Tests` for unit tests,
- `.IntegrationTests` or `.AcceptanceTests` for integration tests.

The benefit of having a unit tests project recognized by Visual Studio is that the developer is able to run the unit tests from within Visual Studio via the [Test Explorer window](https://www.visualstudio.com/en-us/docs/test/developer-testing/getting-started/getting-started-with-developer-testing#run-unit-tests-with-test-explorer) (*Test* → *Windows* → *Test Explorer*), especially when NUnit is used as the testing framework.
The developer can debug unit tests within Visual Studio instead of attaching to the NUnit runner process.

> The developers favoring NUnit should install the [NUnit Test Adapter](https://www.visualstudio.com/en-us/docs/test/developer-testing/getting-started/getting-started-with-developer-testing#q----can-i-run-unit-tests-in-visual-studio-if-i-use-a-different-unit-test-framework) extension to enjoy the benefits mentioned here.

The `Nice.ProjectDefaults.props` introduces the following properties to help build script customizations:
- `IsUnitTestsProject` is `true` when the project is a unit tests project,
- `IsIntegrationTestsProject` is `true` when the project is an integration tests project,
- `IsTestsProject` is `true` if the project is any of the former two.


### Automatically name the XMLDoc file
This feature will automatically name the generated documentation (XMLDoc) file to match the name of the assembly, i.e. `DocumentationFile = $(AssemblyName).xml`.
Instead of manually specifying the `DocumentationFile` property the developer should only set the `GenerateDocumentation` property to `true`.
Note that customizing the `DocumentationFile` property disables/overrides this feature.


### MoveDocumentationFileToOutputPath target
Fixes the issue where the generated documentation (XMLDoc) file is left in the project root to be picked up by the SCM tool (git, hg, etc.) instead of moving it into `./bin` where it is ignored by default.


### Automatically include the project's README file
A project should have a README file but is not required to.
This feature will automatically include (make accessible in Visual Studio) either the `README.md` or the `README.txt` file if they exist in the project's root folder - i.e. the developer does not have to include them manually in the project.


### Automatically set RootNamespace
This feature will automatically set project's `RootNamespace`, if it is not already set, to match the name of the assembly, i.e. `RootNamespace = $(AssemblyName)`.


### Do not force TreatWarningsAsErrors
`TreatWarningsAsErrors` property is by default set to `false`. This does not forces the developer to fix minor issues (warnings) in non-production code (e.g. unit tests) and in production code during development and/or debugging.
The developer will be forced to fix warnings in order to release the main project for deployment to production.
