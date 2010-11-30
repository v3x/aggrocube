using System;

namespace AggrocubeCommon.Protocols
{
    //Probably want [Serializable] here for sending these as packets over the network
    public abstract class Protocol
    {
        private ProtocolID protID;
        public ProtocolID ProtID
        {
            get
            {
                return protID;
            }
            set
            {
                protID = value;
            }
        }
    }
}
