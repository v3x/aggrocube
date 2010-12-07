using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AggrocubeCommon.Blocks;
using AggrocubeCommon.Critters;

namespace AggrocubeClient.UI
{
	public class RenderWindow : GameWindow
	{
		private Matrix4 cameraMatrix;
        private float rotationSpeed = 0.15f;
        private float movementSpeed = 5f;

        //TODO: Any benefits to using Vector2 here?
        private Point currentCursor;
        private Point previousCursor;
        private Point deltaCursor;

        private int textureID;
        private int textureSize = 32;
        private Bitmap textureBitmap = new Bitmap("..//..//..//..//..//media//graphics//textures.png");
        private float textureXInterval;
        private float textureYInterval;

        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("..//..//..//..//..//media//graphics//cursor.png");
        System.Windows.Forms.Cursor myCursor;

        List<Block> blockList = new List<Block>();
        List<VertexBufferObject> vboList = new List<VertexBufferObject>();

        // This is the indices array for the face of each basic block. It's only going to change for torches, etc.
        static int[] Indices =  new int[] { 0, 1, 2, 3 };
        int IndexBufferID;

        // The player of the client
        Player player = new Player(CritterType.PLAYER, new Vector3(0, 0, 0));

		public RenderWindow(string windowTitle, int resHorizontal, int resVertical) 
			: base(resHorizontal, resVertical, GraphicsMode.Default, windowTitle)
		{            
            myCursor = new System.Windows.Forms.Cursor(bitmap.GetHicon());

            //this.WindowState = WindowState.Fullscreen;
            previousCursor = currentCursor = System.Windows.Forms.Cursor.Position;

            textureXInterval = (1f / (textureBitmap.Width / textureSize));
            textureYInterval = (1f / (textureBitmap.Height / textureSize));

            VSync = VSyncMode.On;

            for (int x = 0; x < 2; x++)
            {
                for (int z = 0; z < 2; z++)
                {
                    for (int y = 0; y < 2; y++)
                    {
                        if (y % 2 == 0)
                        {
                            if (z % 2 == 0)
                            {
                                if (x % 2 == 0)
                                {
                                    blockList.Add(new Dirt(x, y, z));
                                }
                                else
                                {
                                    blockList.Add(new Grass(x, y, z));
                                }
                            }
                            else
                            {
                                if (x % 2 == 0)
                                {
                                    blockList.Add(new Grass(x, y, z));
                                }
                                else
                                {
                                    blockList.Add(new Dirt(x, y, z));
                                }
                            }
                        }
                        else
                        {
                            if (z % 2 == 0)
                            {
                                if (x % 2 == 0)
                                {
                                    blockList.Add(new Grass(x, y, z));
                                }
                                else
                                {
                                    blockList.Add(new Dirt(x, y, z));
                                }
                            }
                            else
                            {
                                if (x % 2 == 0)
                                {
                                    blockList.Add(new Dirt(x, y, z));
                                }
                                else
                                {
                                    blockList.Add(new Grass(x, y, z));
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Load buffer for indices of all faces
            GL.GenBuffers(1, out IndexBufferID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(Indices.Length* sizeof(int)), Indices, BufferUsageHint.StaticDraw);            ;

            // Load vertices
            foreach (Block block in blockList)
            {
                vboList.Add(LoadVBO(block));
            }

            GL.ClearColor(0.4f, 0.7f, 0.4f, 0.0f);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.DepthTest);

            textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            BitmapData data = textureBitmap.LockBits(new Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            textureBitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);


        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
            {
                Exit();
            }            
            if (Keyboard[Key.W])
            {
                player.Location += new Vector3(
                    (float)Math.Cos(player.Yaw) * movementSpeed * (float)e.Time,  //X movement
                     0,   //(float)Math.Sin(player.Pitch) * movementSpeed * (float)e.Time, //Y movement
                    (float)Math.Sin(player.Yaw) * movementSpeed * (float)e.Time); //Z movement

                //player.Location.Y += (float)Math.Sin(myCharacter.pitch) * movementSpeed * (float)e.Time;
            }
            if (Keyboard[Key.S])
            {
                player.Location -= new Vector3(
                    (float)Math.Cos(player.Yaw) * movementSpeed * (float)e.Time,  //X movement
                    0,    //(float)Math.Sin(player.Pitch) * movementSpeed * (float)e.Time, //Y movement
                    (float)Math.Sin(player.Yaw) * movementSpeed * (float)e.Time); //Z movement
                
                //player.Location.Y -= (float)Math.Sin(player.Pitch) * movementSpeed * (float)e.Time;
            }
            if (Keyboard[Key.A])
            {
                player.Location -= new Vector3(
                    (float)Math.Cos(player.Yaw + Math.PI / 2) * movementSpeed * (float)e.Time,
                    0,
                    (float)Math.Sin(player.Yaw + Math.PI / 2) * movementSpeed * (float)e.Time);
            }
            if (Keyboard[Key.D])
            {
                player.Location += new Vector3(
                    (float)Math.Cos(player.Yaw + Math.PI / 2) * movementSpeed * (float)e.Time,
                    0,
                    (float)Math.Sin(player.Yaw + Math.PI / 2) * movementSpeed * (float)e.Time);
            }

            UpdateCursorPosition(e);

            Vector3 lookatPoint = new Vector3((float)Math.Cos(player.Yaw), player.Pitch, (float)Math.Sin(player.Yaw));
            cameraMatrix = Matrix4.LookAt(player.Location, player.Location + lookatPoint, Vector3.UnitY);

        }

        private void UpdateCursorPosition(FrameEventArgs e)
        {
            currentCursor = System.Windows.Forms.Cursor.Position;
            deltaCursor = new Point(currentCursor.X - previousCursor.X, currentCursor.Y - previousCursor.Y);

            player.Yaw += deltaCursor.X * rotationSpeed * (float)e.Time;
            player.Pitch -= deltaCursor.Y * rotationSpeed * (float)e.Time;

            //TODO: Need to allow looking straight up and looking straight down without slowing down pitch movement...bind for now
            if (player.Pitch > 3f)
            {
                player.Pitch = 3f;
            }
            else if (player.Pitch < -3f)
            {
                player.Pitch = -3f;
            }

            Rectangle cursorBounds = new Rectangle(Bounds.X + 20, Bounds.Y + 20, Bounds.Width - 40, Bounds.Height - 40);
            if (!cursorBounds.Contains(currentCursor))
            {      
                System.Windows.Forms.Cursor.Position = previousCursor = currentCursor = new Point(this.Bounds.X + (this.Bounds.Width / 2), this.Bounds.Y + (this.Bounds.Height / 2));
            }
            else
            {
                previousCursor = currentCursor;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref cameraMatrix);

            foreach (VertexBufferObject vbo in vboList)
            {
                DrawVBO(vbo);
            }

            SwapBuffers();

            //this.CursorVisible = false;
            System.Windows.Forms.Cursor.Current = myCursor;
        }       

        // TODO: This will create a VBO for each block, but how will we change it after creating it? Keep a list of all VBO objects?
        private VertexBufferObject LoadVBO(Block block)
        {
            VertexBufferObject vbo = new VertexBufferObject();
            //Generate vertex coordinates based on block location
            //Vector3[] Vertices = new Vector3[] { 
            //                                        new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z + 0.5f), // Vector 0
            //                                        new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z + 0.5f), // Vector 1
            //                                        new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z + 0.5f), // Vector 2
            //                                        new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z + 0.5f), // Vector 3
            //                                        new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z - 0.5f), // Vector 4
            //                                        new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z - 0.5f), // Vector 5
            //                                        new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z - 0.5f), // Vector 6
            //                                        new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z - 0.5f)  // Vector 7
            //                                    };

            Vector3[][] Vertices = new Vector3[][]{
                                                        new Vector3[] { new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z + 0.5f), new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z + 0.5f), new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z + 0.5f), new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z + 0.5f) },   // Face 0 (Front)
                                                        new Vector3[] { new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z - 0.5f), new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z - 0.5f), new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z - 0.5f), new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z - 0.5f) },   // Face 1 (Back)
                                                        new Vector3[] { new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z - 0.5f), new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z - 0.5f), new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z + 0.5f), new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z + 0.5f) },   // Face 2 (Left)
                                                        new Vector3[] { new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z + 0.5f), new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z + 0.5f), new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z - 0.5f), new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z - 0.5f) },   // Face 3 (Right)
                                                        new Vector3[] { new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z + 0.5f), new Vector3(block.X - 0.5f, block.Y + 0.5f, block.Z - 0.5f), new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z - 0.5f), new Vector3(block.X + 0.5f, block.Y + 0.5f, block.Z + 0.5f) },   // Face 4 (Top)
                                                        new Vector3[] { new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z - 0.5f), new Vector3(block.X - 0.5f, block.Y - 0.5f, block.Z + 0.5f), new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z + 0.5f), new Vector3(block.X + 0.5f, block.Y - 0.5f, block.Z - 0.5f) }    // Face 5 (Bottom)
                                                  };

            //Generate texture coordinates based on block type
            int textureLocationX = (int)block.Type % (textureBitmap.Width / textureSize); //The X position of the texture in the bitmap.
            int textureLocationY = (int)block.Type % (textureBitmap.Height / textureSize); //The Y position of the texture in the bitmap.

            float textureLeft = (float)textureLocationX * textureXInterval; //The relative position of the left side of the texture in the bitmap
            float textureRight = textureLeft + textureXInterval; //The relative position of the right side of the texture in the bitmap
            float textureTop = (float)textureLocationY * textureYInterval; //The relative position of the bottom side of the texture in the bitmap
            float textureBottom = textureTop + textureYInterval; //The relative position of the top side of the texture in the bitmap           

            Vector2[] Textures = new Vector2[] {
                                                    new Vector2(textureLeft, textureBottom), 
                                                    new Vector2(textureLeft, textureTop), 
                                                    new Vector2(textureRight, textureTop), 
                                                    new Vector2(textureRight, textureBottom)
                                               };

            //Generate buffer IDs
            vbo.VertexBufferID = new int[Vertices.GetLength(0)];
            GL.GenBuffers(Vertices.GetLength(0), out vbo.VertexBufferID[0]);            
            GL.GenBuffers(1, out vbo.TextureBufferID);

            //Bind the vertices
            for (int i = 0; i < Vertices.GetLength(0); i++)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.VertexBufferID[i]);
                GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Vertices[i].Length * Vector3.SizeInBytes), Vertices[i], BufferUsageHint.DynamicDraw);
            }

            //Bind the textures
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.TextureBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Textures.Length * Vector2.SizeInBytes), Textures, BufferUsageHint.DynamicDraw);

            return vbo;
        }

        private void DrawVBO(VertexBufferObject vbo)
        {
            // Bindings for drawing textures
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.TextureBufferID);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, Vector2.SizeInBytes, IntPtr.Zero);
            GL.EnableClientState(ArrayCap.TextureCoordArray);

            // Bindings for indices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferID);

            // Bindings for drawing vertices            
            GL.EnableClientState(ArrayCap.VertexArray);
            for (int i = 0; i < vbo.VertexBufferID.Length; i++ )
            {                
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.VertexBufferID[i]);
                GL.VertexPointer(3, VertexPointerType.Float, Vector3.SizeInBytes, IntPtr.Zero);
                GL.DrawElements(BeginMode.Quads, Indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
            }
        }
		
		public static void Create() 
		{
			using(RenderWindow renderWindow = new RenderWindow("Aggrocube", 800, 600))
            {
                renderWindow.Run(30.0);
            }
		}
	}

    struct VertexBufferObject
    {
        public int[] VertexBufferID;   // Holds an array of buffer ID's for the vertices of each face of the cube
        public int TextureBufferID;  //Holds the buffer ID for the textures.
        //public int IndexBufferID;  // Holds the buffer ID to the indices
        //public int NumElements;      // Number of elements to be drawn
    }
}

