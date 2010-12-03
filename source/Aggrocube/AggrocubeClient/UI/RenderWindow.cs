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
        private double textureXInterval;
        private double textureYInterval;

        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("..//..//..//..//..//media//graphics//cursor.png");
        System.Windows.Forms.Cursor myCursor;

        List<Block> blockList = new List<Block>();

        VirtualBufferObject myCube;

        // The player of the client
        Player player = new Player(CritterType.PLAYER, new Vector3(10, 0, 10));

		public RenderWindow(string windowTitle, int resHorizontal, int resVertical) 
			: base(resHorizontal, resVertical, GraphicsMode.Default, windowTitle)
		{            
            myCursor = new System.Windows.Forms.Cursor(bitmap.GetHicon());

            //this.WindowState = WindowState.Fullscreen;
            previousCursor = currentCursor = System.Windows.Forms.Cursor.Position;

            textureXInterval = (1.0 / (textureBitmap.Width / textureSize));
            textureYInterval = (1.0 / (textureBitmap.Height / textureSize));

            VSync = VSyncMode.On;

            for (int x = 0; x < 50; x++)
            {
                for (int z = 0; z < 50; z++)
                {
                    if (z % 2 == 0)
                    {
                        if (x % 2 == 0)
                        {
                            blockList.Add(new Dirt(x, -2, z));
                        }
                        else
                        {
                            blockList.Add(new Grass(x, -2, z));
                        }
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            blockList.Add(new Grass(x, -2, z));
                        }
                        else
                        {
                            blockList.Add(new Dirt(x, -2, z));
                        }
                    }
                }
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Load our vertex buffers here...hopefully we can do it elsewhere too...
            Dirt dirt = new Dirt(0, -2, 0);
            myCube = CreateVBO(dirt);

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
                    0,                                                            //Y movement
                    (float)Math.Sin(player.Yaw) * movementSpeed * (float)e.Time); //Z movement

                //player.Location.Y += (float)Math.Sin(myCharacter.pitch) * movementSpeed * (float)e.Time;
            }
            if (Keyboard[Key.S])
            {
                player.Location -= new Vector3(
                    (float)Math.Cos(player.Yaw) * movementSpeed * (float)e.Time,  //X movement
                    0,                                                            //Y movement
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
            //if (player.Pitch > 3f)
            //{
            //    player.Pitch = 3f;
            //}
            //else if (player.Pitch < -3f)
            //{
            //    player.Pitch = -3f;
            //}

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

            //foreach (Block block in blockList)
            //{
            //    DrawBlock(block);
            //}

            DrawVBO(myCube);

            SwapBuffers();

            //this.CursorVisible = false;
            System.Windows.Forms.Cursor.Current = myCursor;
        }

        private void DrawBlock(Block block)
        {
            DrawBlock(block.X, block.Y, block.Z, block.Type);
        }

		private void DrawBlock(float x, float y, float z, BlockType blockType)
        {
            int textureLocationX = (int)blockType % (textureBitmap.Width / textureSize); //The X position of the texture in the bitmap.
            int textureLocationY = (int)blockType / (textureBitmap.Width / textureSize); //The Y position of the texture in the bitmap

            double textureLeft = (double)textureLocationX * textureXInterval; //The relative position of the left side of the texture in the bitmap
            double textureRight = textureLeft + textureXInterval; //The relative position of the right side of the texture in the bitmap

            double textureBottom = (double)textureLocationY * textureYInterval; //The relative position of the bottom side of the texture in the bitmap
            double textureTop = textureBottom + textureYInterval; //The relative position of the top side of the texture in the bitmap           

            GL.BindTexture(TextureTarget.Texture2D, textureID);
           // GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest); //Don't blur the pixels
            GL.Begin(BeginMode.Quads);

            //Face 1 (Front)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x - 0.5, y - 0.5, z + 0.5);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x - 0.5, y + 0.5, z + 0.5);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 0.5, y + 0.5, z + 0.5);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 0.5, y - 0.5, z + 0.5);

            //Face 2 (Back)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x + 0.5, y - 0.5, z - 0.5);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x + 0.5, y + 0.5, z - 0.5);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x - 0.5, y + 0.5, z - 0.5);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x - 0.5, y - 0.5, z - 0.5);

            //Face 3 (Left)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x - 0.5, y - 0.5, z - 0.5);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x - 0.5, y + 0.5, z - 0.5);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x - 0.5, y + 0.5, z + 0.5);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x - 0.5, y - 0.5, z + 0.5);

            //Face 4 (Right)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x + 0.5, y - 0.5, z + 0.5);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x + 0.5, y + 0.5, z + 0.5);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 0.5, y + 0.5, z - 0.5);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 0.5, y - 0.5, z - 0.5);

            //Face 5 (Top)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x - 0.5, y + 0.5, z + 0.5);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x - 0.5, y + 0.5, z - 0.5);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 0.5, y + 0.5, z - 0.5);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 0.5, y + 0.5, z + 0.5);

            //Face 6 (Bottom)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x - 0.5, y - 0.5, z - 0.5);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x - 0.5, y - 0.5, z + 0.5);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 0.5, y - 0.5, z + 0.5);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 0.5, y - 0.5, z - 0.5);

            GL.End();
		}

        // This will create a VBO for each block, but how will we change it after creating it? Keep a list of all VBO objects?
        // Right now we are putting the indices into the buffer with each block...we really only need one indices VBO for basic blocks.
        // Also, take Vertices out of Block.cs and put it in here...generate it based on the block coordinates. When chunks are implemented, base it on those.
        // Still need to do texture...want to generate a texture VBO based on blocktype.
        private VirtualBufferObject CreateVBO(Block block)
        {
            VirtualBufferObject vbo = new VirtualBufferObject();

            // Generate buffer for vertices
            GL.GenBuffers(1, out vbo.VertexBufferID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.VertexBufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(block.Vertices.Length * Vector3.SizeInBytes), block.Vertices, BufferUsageHint.DynamicDraw);
           
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //Clear binding

            //Generate buffer for indices
            GL.GenBuffers(1, out vbo.ElementBufferID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vbo.ElementBufferID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(block.Indices.Length * sizeof(int)), block.Indices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            vbo.NumElements = block.Indices.Length;

            return vbo;
        }

        private void DrawVBO(VirtualBufferObject vbo)
        {
            //Look up what this does :P
            GL.PushClientAttrib(ClientAttribMask.ClientVertexArrayBit);

            // Bindings for vertices
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.VertexBufferID);
            GL.VertexPointer(3, VertexPointerType.Float, Vector3.SizeInBytes, IntPtr.Zero);
            GL.EnableClientState(EnableCap.VertexArray);

            //Bindings for indices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vbo.ElementBufferID);

            //Draw vertices as directed by indices

            GL.DrawElements(BeginMode.Quads, vbo.NumElements, DrawElementsType.UnsignedInt, IntPtr.Zero);

            GL.PopClientAttrib();
        }
		
		public static void Create() 
		{
			using(RenderWindow renderWindow = new RenderWindow("Aggrocube", 800, 600))
            {
                renderWindow.Run(30.0);
            }
		}
	}

    struct VirtualBufferObject
    {
        public int VertexBufferID;   // Holds the buffer id to the vertices
        public int ElementBufferID;  // Holds the buffer id to the indices
        public int NumElements;      // Number of elements to be drawn...for block it's just 24. Probably need to change this for torches, etc.
    }
}

