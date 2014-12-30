VSProjectReferenceFixerAddin
============================

A Visual Studio Add In that looks for assembly references between projects and replaces them with proper Project References

Did you messed up when adding the references to a project and used assembly references instead of project references? This visual studio add-in will fix your solution for you.

Tested on Visual Studio 2010 and 2013.

Installation
------------
* Create folder %APPDATA%\Microsoft\MsEnvShared\Addins
* Download [release](https://github.com/gerardog/VSProjectReferenceFixerAddin/releases/download/0.1/FixReferencesAddIn.zip) and unzip there.
* Restart Visual Studio



How to use
----------
In visual studio, Go to Tools -> FixReferencesAddIn

Look at the results in the Output window. For Example:
```
 Project a generates assembly: a
 Project b generates assembly: b
 Fixing References on project b for project a
```
