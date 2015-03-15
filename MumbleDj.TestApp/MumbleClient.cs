using System;
using MumbleDj.Packets;

namespace MumbleDj.TestApp
{
    public class MumbleClient
    {
        private readonly MumbleConnection _mumbleConnection;

        public MumbleClient(MumbleConnection mumbleConnection)
        {
            _mumbleConnection = mumbleConnection;
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

        public void Process()
        {
            _mumbleConnection.Process();
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