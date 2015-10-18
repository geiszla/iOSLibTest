# iOSLibTest
iOSLibTest is a project for testing and understanding [iOSLib](https://github.com/geiszla/iOSLib). To use functions, just uncomment their lines. To find the source of exceptions include the iOSLib source to the same solution, and make a reference to the built dll (in \iOSLib\iOSLib\bin).

##Requirements
 - .NET 4 (Client profile)
 - iOSLib dll and all dependencies (included in [iOSLib release 7z](https://github.com/geiszla/iOSLib/releases))
 - System.Data.Sqlite (from NuGet package manager)

##Setting up
1. Due to the fact, that LibiMobileDevice library is only compiled to 32-bit (x86) Windows, you have to <b>change the target CPU architecture of the project</b>. To do it click "Any CPU" at the toolbar (next to "Debug") and select "x86". If it isn't already there, click "Configuration Manager...", then click "Any CPU" at the top of the newly opened window, select "\<New\>", select "x86" instead of "x64", click OK, click close and you're done. (Note, that you have to change this again if you change "Debug" to "Release")
2. Build the project once (don't mind the missing "iOSLib" reference)
3. Place all dlls from [iOSLib release](https://github.com/geiszla/iOSLib/releases) into the build folder (usually iOSLibTest\bin\\<b>x86</b>\Debug).
4. Add reference to iOSLib.dll: In solution explorer (usually the panel on the right), right click to References -> Add Reference... -> Browse... (on the bottom) -> select iOSLib.dll from the previous build location (iOSLibTest\bin\\<b>x86</b>\Debug) -> click OK.
5. You're done, just hit F5, and wait for magic to happen

##Documentation
For more info on iOSLib source code and individual functions see wiki pages [here](https://github.com/geiszla/iOSLib/wiki)

##Feedback
Feel free to report all bugs you found by creating a new issue [here](https://github.com/geiszla/iOSLibTest/issues).
