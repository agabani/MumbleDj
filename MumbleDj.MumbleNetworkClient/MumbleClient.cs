using System;
using MumbleDj.MumbleNetworkClient.Models;
using MumbleDj.Packets;

namespace MumbleDj.MumbleNetworkClient
{
    public class MumbleClient
    {
        private readonly MumbleConnection _mumbleConnection;
        private int _millisecondsTimeout = 100;

        public MumbleClient(MumbleConnection mumbleConnection)
        {
            _mumbleConnection = mumbleConnection;
        }

        public bool IsConnected
        {
            get { return _mumbleConnection.ConnectionState == ConnectionStates.Connected; }
        }

        public int MillisecondsTimeout
        {
            get { return _millisecondsTimeout; }
            set { _millisecondsTimeout = value; }
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
            _mumbleConnection.Process(_millisecondsTimeout);
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