using EasyNetQ;
using Exemplo.Rabbit.Messages;
using System;

namespace Exemplo.Rabbit.SConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                //bus.PubSub.Subscribe<TextMessages>(string.Empty, HandleTextMessage, x => x.WithQueueName("Teste"));
                bus.SendReceive.Receive<TextMessages>("Teste", message => Console.WriteLine("Texto da mensagem: {0}", message.Mensagem));

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TextMessages textMessage)
        {
            Console.WriteLine("Got message: {0}", textMessage.Mensagem);
            Console.ResetColor();
        }
    }
}
