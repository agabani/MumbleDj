using System;

namespace MumbleDj.TestApp
{
    internal class Program
    {
        private static void Main()
        {
            var address = new MumbleAddress {Address = "localhost", Port = 64738};
            var credentials = new MumbleCredentials {Username = "MumbleDj", Password = string.Empty};

            var proxyCallback = new MumbleProxyCallback();

            var connection = new MumbleConnection(address, proxyCallback);
            var client = new MumbleClient(connection);
            var application = new MumbleApplication(client, credentials);

            proxyCallback.MumbleCallback = application;

            application.Run();

            Console.ReadLine();
        }
    }
}