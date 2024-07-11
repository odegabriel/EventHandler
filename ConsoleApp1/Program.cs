using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace Deligate

{
    public delegate void EventHandler (object sender, EventArgs e);
    public delegate void EventHandler <T> (object sender, T e);

    //public delegate void EventHandler(string message);
    public class DeligateCOn
    {
      
        private static void Main(string[] args)
        {





            //      Publisher publisher = new Publisher();
            //    Subcriber subcriber = new Subcriber();

            //  publisher.Onmessage += subcriber.HandleMessage;

            // publisher.SendMessage("hello all of you");

            Publisher publish = new Publisher();
            Subcriber subcribe = new Subcriber();

            publish.Onmessage += subcribe.HandleMessage;

            publish.sendMessage("hello all");



        }

    }

    public class MessageEventArgs : EventArgs
    {
        public string Message { get; }
        public MessageEventArgs(string message)
        {
            Message = message;
        }

    }

    public class Publisher
    {
        public event EventHandler <MessageEventArgs>  Onmessage;
        public void sendMessage(string message)
        {
            Onmessage?.Invoke(this, new MessageEventArgs(message));
        }
    }

    public class Subcriber
    {
        public void HandleMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"Recieved message: {e.Message}");
        }

        //public class Publisher
        //{
        //    public event EventHandler Onmessage;

        //    public void SendMessage(string message)
        //    {
        //        Onmessage?.Invoke(message);
        //    }
        //}

        //public class  Subcriber 
        //{
        //    public void HandleMessage(string message)
        //    {
        //        Console.WriteLine($"recieved the message {message}");
        //    }
        //}

    }
}
