using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteObjects;

namespace TheClient
{
    /* ***********************************************************
     * The Client
     *********************************************************** */

    class Program
    {
        static void Main(string[] args)
        {
            // select channel to communicate with server
            TcpChannel clientChanel = new TcpChannel();
            ChannelServices.RegisterChannel(clientChanel, false);

            Type cType = typeof(RemoteObject);
            RemoteObject remObject = (RemoteObject)Activator.GetObject(cType, "tcp://localhost:8085/RemotingServer");

            string message = remObject.ReplyMessage("You there?");

            Console.WriteLine(message);

            // RemotingConfiguration.RegisterWellKnownClientType(cType, "tcp://localhost:8085/ShowCapital");

            Console.ReadLine(); // need to stop server from shutting down, don't we?
        }
    }
}
