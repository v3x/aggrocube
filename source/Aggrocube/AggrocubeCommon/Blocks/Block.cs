using System;
using OpenTK;
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

        // This is not going to work in the long run...we want x, y, and z to indicate each block's position within its chunk, not absolute OpenGL coordinates.
        // We should generate this vector array for every block we add, based on the chunk's coordinates and the block's coordinates within the chunk.
        public Vector3[] Vertices
        {
            get
            {  

                return new Vector3[] { new Vector3(x - 0.5f, y - 0.5f, z + 0.5f), 
                                       new Vector3(x - 0.5f, y + 0.5f, z + 0.5f),
                                       new Vector3(x + 0.5f, y + 0.5f, z + 0.5f), 
                                       new Vector3(x + 0.5f, y - 0.5f, z + 0.5f),
                                       new Vector3(x + 0.5f, y - 0.5f, z - 0.5f), 
                                       new Vector3(x + 0.5f, y + 0.5f, z - 0.5f), 
                                       new Vector3(x - 0.5f, y + 0.5f, z - 0.5f), 
                                       new Vector3(x - 0.5f, y - 0.5f, z - 0.5f) };
            }
        }

        // This holds the references to the Vector3 in Vertices that applies for each face. It's never going to change as long as we are drawing blocks.
        public int[] Indices
        {
            get
            {
                return new int[] {
                                    0, 1, 2, 3, // Face 1 (Front)
                                    4, 5, 6, 7, // Face 2 (Back)
                                    5, 6, 1, 0, // Face 3 (Left)
                                    3, 2, 7, 4, // Face 4 (Right)
                                    1, 6, 7, 2, // Face 5 (Top)
                                    5, 0, 3, 4
                                 };
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

