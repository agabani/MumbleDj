using System;
using System.Threading;

namespace MumbleDj.TestApp
{
    internal class Program
    {
        private static void Main()
        {
            var mumbleClient = new MumbleClient("localhost", 64738);
            mumbleClient.Connect("MumbleDj", string.Empty);

            var t = new Thread(a => UpdateLoop(mumbleClient)) {IsBackground = true};
            t.Start();

            Console.ReadLine();
        }

        private static void UpdateLoop(MumbleClient client)
        {
            while (true)
            {
                client.Process();
            }
        }
    }
}