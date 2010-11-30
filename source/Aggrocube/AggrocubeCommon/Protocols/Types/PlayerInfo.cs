using System;


namespace AggrocubeCommon.Protocols.Types
{
    class PlayerInfo : Protocol
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
        }

        public PlayerInfo(string username)
        {
            this.ProtID = ProtocolID.PLAYER_INFO;
            this.username = username;            
        }
    }
}
