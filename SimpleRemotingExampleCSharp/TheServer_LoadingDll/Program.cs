using System;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace TheServer_LoadingDll
{
    /* ***********************************************************
     * The Server - exposing from dll
     * Explanation: If you look closely to "References" of this project, you can see that we don't
     * reference "RemoteObjects" project. We rather load data about our class from .dll
     *********************************************************** */
    class Program
    {
        static void Main(string[] args)
        {
            // select channel to communicate
            TcpChannel serverChanel = new TcpChannel(8085);

            // register channel
            ChannelServices.RegisterChannel(serverChanel, false);  // bool param is for "EnsureSecurity" var, more in decompiled dll

            // path to dll
            string dllPath = "../../dllLibrary/RemoteObjects.dll";

            // We are doing this because (if we managed our exceptions) we would get with current path "Absolute path information is required." exception
            //  when dynamically loading .dll's.
            if (!Path.IsPathRooted(dllPath))
                dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + dllPath;

            // Get type of the class we want to get
            Type type = null;

            // Load Dll using reflection
            var DLL = Assembly.LoadFile(dllPath);

            // Get specific type using $"{namespace}.{className}" and get type of the class we need
            type = DLL.GetType("RemoteObjects.RemoteObject");

            // If we need to call method in selected class right away, we should do something like below
            // var c = Activator.CreateInstance(type);      // create instance of class in memory
            // var method = type.GetMethod("ReplyMessage"); // select method inside class
            // method.Invoke(c, new object[] { @"Hello" }); // then invoke it, with parameters (null if method take no params)


            // Overkill: Go trough all of the types in .dll and assign it to our type - This is a bit of overkill so we wont be using this
            //foreach (Type dllType in DLL.GetExportedTypes())
            //{
            //    type = dllType;
            //    var c = Activator.CreateInstance(dllType);
            //    // type1.InvokeMember("Output", BindingFlags.InvokeMethod, null, c, new object[] { @"Hello" });
            //}

            // register remote object
            RemotingConfiguration.RegisterWellKnownServiceType(type, "RemotingServer", WellKnownObjectMode.SingleCall);

            // inform console
            Console.WriteLine("Server Activated \n");
            Console.ReadLine(); // need to stop server from shutting down, don't we?
        }
    }
}
