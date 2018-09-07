using System;

namespace RemoteObjects
{
    public class RemoteObject : MarshalByRefObject
    {
        // constructor
        public RemoteObject()
        {
            Console.WriteLine("Remote object activated");
        }

        // return message reply
        public string ReplyMessage(string msg)
        {
            Console.WriteLine("Client : " + msg); // print given message on console 
            return "Server : Yeah! I'm here";
        }
    }
}
