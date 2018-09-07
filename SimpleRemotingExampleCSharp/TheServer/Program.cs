using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteObjects;

namespace TheServer
{
    /* ***********************************************************
     * The Server
     *********************************************************** */
    class Program
    {

        static void Main(string[] args)
        {
            // select channel to communicate
            TcpChannel serverChanel = new TcpChannel(8085);

            // register channel
            ChannelServices.RegisterChannel(serverChanel, false);  // bool param is for "EnsureSecurity" var, more in decompiled dll

            // Get type of the class we want to get
            // Type type = Type.GetType("RemotingSamples.RemoteObject,object");
            Type type = typeof(RemoteObject);

            // register remote object
            RemotingConfiguration.RegisterWellKnownServiceType(type, "RemotingServer", WellKnownObjectMode.SingleCall);

            // inform console
            Console.WriteLine("Server Activated \n");
            Console.ReadLine(); // need to stop server from shutting down, don't we?
        }
    }
}
