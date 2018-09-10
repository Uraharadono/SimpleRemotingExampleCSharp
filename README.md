# Simple Remoting Example in CSharp / C#

Project that shows simple usage of remoting in C# to expose classes over tcp over the network.


# TheServer_LoadingDll project

This project is not referencing our model project ("RemoteObjects" project). It is actually using reflection to load .dll file dynamically, and then resolving it's type. 

*Note:* This would mean that we don't need models in separate project, (in this case "RemoteObjects") and could be moved to "TheClient" project, and "RemoteObjects" project could be removed.
