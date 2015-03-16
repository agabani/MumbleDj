using System;
using MumbleDj.MumbleNetworkClient;
using MumbleDj.MumbleNetworkClient.Callbacks;
using MumbleDj.MumbleNetworkClient.Models;

namespace MumbleDj.TestApp
{
    internal class Program
    {
        private static void Main()
        {
            var address = new MumbleAddress {Address = "localhost", Port = 64738};
            var credentials = new MumbleCredentials {Username = "MumbleDj", Password = string.Empty};

            var router = new MumbleCallbackRouter();
            var display = new ConsoleWriteLineCallback();

            var connection = new MumbleConnection(address, router);
            var client = new MumbleClient(connection);
            var application = new MumbleApplication(client, credentials);

            router.Register(display);
            router.Register(application);

            application.Run();

            Console.ReadLine();
        }
    }
}