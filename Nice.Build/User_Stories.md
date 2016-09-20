# Nice.Build User Stories

- [x] Automatically detect a unit test project (based on project naming convention(s)) and mark it accordingly so the [Visual Studio Test Explorer](https://msdn.microsoft.com/en-us/library/hh270865.aspx) can automatically find the unit tests.  
The main project named `${project}.*proj` should have a matching unit tests project named `${project}.UnitTests.*proj` (or `${project}.Tests.*proj`).
- [x] Also support `${project}.IntegrationTests.*proj` and `${project}.AcceptanceTests.*proj`.
- [ ] Mark the test project correctly depending on its file extension, i.e. the project type GUID differs between C#, C++, Visual Basic, etc.
  - [x] Mark the `.csproj` test project correctly.
  - [x] Mark the `.fsproj` test project correctly.
  - [x] Mark the `.vbproj` test project correctly.
  - [x] Mark the `.vcxproj` test project correctly.
  - [ ] Mark [other kinds of projects](http://www.codeproject.com/Reference/720512/List-of-Visual-Studio-Project-Type-GUIDs).
- [x] Name the generated XMLDoc (technical documentation) file the same as the assembly, i.e. reuse the `AssemblyName` property.
- [x] Move the generated XMLDoc file from the project root into `OutputPath` so it can be ignored by the SCM (Git, Mercurial, etc.).
- [x] Automatically include the project's README file.