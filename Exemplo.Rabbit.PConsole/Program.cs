using EasyNetQ;
using Exemplo.Rabbit.Messages;
using System;
using System.Threading.Tasks;

namespace Exemplo.Rabbit.PConsole
{
    class Program
    {
        static void Main(string[] args)
        {           
            var input = String.Empty;
            long cell = 0;
            Console.WriteLine("Enter a message. 'Quit' to quit.");
            while ((input = Console.ReadLine()) != "Quit")
            {
                Console.WriteLine("Enter a cellphone just numbers.");
                cell = long.TryParse(Console.ReadLine(), out cell) ? cell : 0;

                if (cell == 0)
                {
                    Console.WriteLine("Start again and use just numbers!");
                    Console.WriteLine("Enter a message. 'Quit' to quit.");
                }
                else
                {

                    var a = new TextMessages(1, input, cell);

                    PublishMessageAsync(a);
                    Console.WriteLine("Message published!");
                    Console.WriteLine("Enter a message. 'Quit' to quit.");
                }

            }

        }

        public static void PublishMessageAsync(TextMessages message)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                try
                {
                    bus.SendReceive.Send("Teste", message);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message); ;
                }             

                bus.Dispose();
            }
        }
    }
}