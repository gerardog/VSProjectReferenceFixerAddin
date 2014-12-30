VSProjectReferenceFixerAddin
============================

A Visual Studio Add In that looks for assembly references between projects and replaces them with proper Project References

Did you messed up when adding the references to a project and used assembly references instead of project references?


Installation
------------
Create folder %APPDATA%\Microsoft\MsEnvShared\Addins
Download release.ZIP and unzip there.
Restart Visual Studio

Notes:

How to use
----------
In visual studio, Go to Tools -> FixReferencesAddIn

Look at the results in the Output window. For Example:
```
 Project a generates assembly: a
 Project b generates assembly: b
 Fixing References on project b for project a
```