using System;
using OpenTK;

namespace AggrocubeCommon.Critters
{
	public abstract class Critter : ICritter
	{
		private CritterType type;
		private Vector3 location;
        private float pitch;
        private float yaw;
		
		public CritterType Type 
		{ 
			get 
			{
				return type; 
			}
			set
			{
				type = value;
			}
		}
		
		public Vector3 Location 
		{ 
			get 
			{ 
				return location; 
			}
            set
            {
                location = value;
            }
		}

        public float Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
            }
        }

        public float Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                yaw = value;
            }
        }
		
		public Critter () 
		{
		}
		
		public Critter (CritterType type, Vector3 location) 
		{
			this.type = type;
            this.location = location;
            pitch = 0f;
            yaw = 0f;
		}
	}
}

