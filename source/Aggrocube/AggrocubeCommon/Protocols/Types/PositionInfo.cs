using System;

namespace AggrocubeCommon.Protocols.Types
{
    class PositionInfo : Protocol
    {
        private short x;
        public short X
        {
            get
            {
                return x;
            }
        }

        private short y;
        public short Y
        {
            get
            {
                return y;
            }
        }

        private short z;
        public short Z
        {
            get
            {
                return z;
            }
        }

        private byte pitch;
        public byte Pitch
        {
            get
            {
                return pitch;
            }
        }

        private byte yaw;
        public byte Yaw
        {
            get
            {
                return yaw;
            }
        }

        private byte playerID;
        public byte PlayerID
        {
            get
            {
                return playerID;
            }
        }

        public PositionInfo(short x, short y, short z, byte pitch, byte yaw, byte playerID)
        {
            this.ProtID = ProtocolID.POSITION_INFO;
            this.x = x;
            this.y = y;
            this.z = z;
            this.pitch = pitch;
            this.yaw = yaw;
            this.playerID = playerID;
            
        }
    }
}
