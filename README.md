# csharp-updater
This Code can be used in combination with WinRAR SFX Archive to Update and overwrite you C# Application. It will check on a server for a file named "version.txt" if the content of this file is higher than the assembly version number. If true, it downloads the SFX Archive named "update.exe" and executes if the downloaded file is present. If not, it will through an exception. Also: When the Update is found and downloaded, the file "update.exe" gets executed and the C# Application closes itself, because there would be an overwriting error while trying to update current binaries etc.

# Requirements
- C# Application (WinForm prefered
- Server (to host version.txt and update.exe)

# License
Do whatever you want but dont sell it or tell people you did it because i was the person sitting down on this trying to work around those integrated, complicated updaters on the market. 

# Final Words
I hope i was able to help you. i would like to hear if it worked or not because it looks like a lot of people have issues if updating their Applications in the wild. If there are any issues just tell me and i will help :)
