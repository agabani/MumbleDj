using System;
using System.Threading;
using MumbleDj.MumbleNetworkClient.Models;
using MumbleDj.Packets;

namespace MumbleDj.MumbleNetworkClient
{
    public class MumbleClient
    {
        private readonly MumbleConnection _mumbleConnection;
        private readonly MumbleCredentials _mumbleCredentials;

        public MumbleClient(MumbleConnection mumbleConnection, MumbleCredentials mumbleCredentials)
        {
            _mumbleConnection = mumbleConnection;
            _mumbleCredentials = mumbleCredentials;
        }

        public bool IsConnected
        {
            get { return _mumbleConnection.ConnectionState == ConnectionStates.Connected; }
        }

        public void Connect(MumbleCredentials mumbleCredentials)
        {
            _mumbleConnection.Connect(mumbleCredentials);
        }

        public void Disconnect()
        {
            _mumbleConnection.Disconnect();
        }

        public void Start()
        {
            Connect(_mumbleCredentials);
            Run();
        }

        private void Run()
        {
            var thread = new Thread(updateLoop => UpdateLoop()) {IsBackground = true};
            thread.Start();
        }

        private void UpdateLoop()
        {
            while (IsConnected)
            {
                _mumbleConnection.Process();
            }
        }

        public void Send<T>(PacketType type, T packet)
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Not connected.");
            }

            _mumbleConnection.Send(type, packet);
        }
    }
}