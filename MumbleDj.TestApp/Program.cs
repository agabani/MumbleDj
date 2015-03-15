using System;
using System.Threading;

namespace MumbleDj.TestApp
{
    internal class Program
    {
        private static void Main()
        {
            var address = new MumbleAddress { Address = "localhost", Port = 64738 };
            var credentials = new MumbleCredentials {Username = "MumbleDj", Password = string.Empty};
            var callback = new MumbleCallback();
            var connection = new MumbleConnection(address, callback);
            var client = new MumbleClient(connection);

            client.Connect(credentials);

            var t = new Thread(a => UpdateLoop(client)) { IsBackground = true };
            t.Start();

            Console.ReadLine();
        }

        private static void UpdateLoop(MumbleClient client)
        {
            while (client.IsConnected)
            {
                client.Process();
            }
        }
    }
}