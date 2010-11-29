using System;
namespace AggrocubeCommon.Critters
{
	public abstract class Critter : ICritter
	{
		private CritterType type;
		private int x, y, z;
		
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
		
		public int X 
		{ 
			get 
			{ 
				return x; 
			}
		}
		
		public int Y 
		{ 
			get 
			{ 
				return y; 
			}
		}
		
		public int Z 
		{ 
			get 
			{ 
				return z;
			} 
		}
		
		public Critter () 
		{
		}
		
		public Critter (CritterType type, int x, int y, int z) 
		{
			this.type = type;
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}

