using System;
namespace AggrocubeCommon.Blocks
{
	public abstract class Block : IBlock
	{
		private BlockType type;
		private int x, y, z;
		
		public BlockType Type 
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
		
		public Block () 
		{
		}
		
		public Block (BlockType type, int x, int y, int z) 
		{
			this.type = type;
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}

