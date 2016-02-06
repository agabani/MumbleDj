using System;
using MumbleDj.Audio;
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

            var connection = new MumbleConnection(address, router);
            var client = new MumbleClient(connection, credentials);

            var display = new ConsoleWriteLineCallback();
            var application = new MumbleApplication(client);
            var audio = new MumbleAudio();

            router.Register(display);
            router.Register(application);
            router.Register(audio);

            client.Start();

            Console.ReadLine();
        }
    }
}