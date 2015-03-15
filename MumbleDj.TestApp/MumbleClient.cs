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
    }
}