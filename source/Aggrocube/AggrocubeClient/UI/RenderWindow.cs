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
namespace AggrocubeClient.UI
{
	public class RenderWindow : GameWindow
	{
		private Matrix4 cameraMatrix;
        private float rotationSpeed = 0.15f;

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
		
		public RenderWindow(string windowTitle, int resHorizontal, int resVertical) 
			: base(resHorizontal, resVertical, GraphicsMode.Default, windowTitle)
		{
            myCursor = new System.Windows.Forms.Cursor(bitmap.GetHicon());

            this.WindowState = WindowState.Fullscreen;
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


            cameraMatrix = Matrix4.CreateTranslation(0f, 0f, 0f);
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
            else if (Keyboard[Key.W])
            {
                cameraMatrix = Matrix4.Mult(cameraMatrix, Matrix4.CreateTranslation(0f, 0f, 10f * (float)e.Time));
            }
            else if (Keyboard[Key.S])
            {
                cameraMatrix = Matrix4.Mult(cameraMatrix, Matrix4.CreateTranslation(0f, 0f, -10f * (float)e.Time));
            }
            else if (Keyboard[Key.A])
            {
                cameraMatrix = Matrix4.Mult(cameraMatrix, Matrix4.CreateTranslation(10f * (float)e.Time, 0f, 0f));
            }
            else if (Keyboard[Key.D])
            {
                cameraMatrix = Matrix4.Mult(cameraMatrix, Matrix4.CreateTranslation(-10f * (float)e.Time, 0f, 0f));
            }

            UpdateCursorPosition(e);

        }

        private void UpdateCursorPosition(FrameEventArgs e)
        {
            currentCursor = System.Windows.Forms.Cursor.Position;
            deltaCursor = new Point(currentCursor.X - previousCursor.X, currentCursor.Y - previousCursor.Y);

            cameraMatrix = Matrix4.Mult(cameraMatrix, Matrix4.CreateRotationY(deltaCursor.X * rotationSpeed * (float)e.Time));
            cameraMatrix = Matrix4.Mult(cameraMatrix, Matrix4.CreateRotationX(deltaCursor.Y * rotationSpeed * (float)e.Time));
            
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

            foreach (Block block in blockList)
            {
                DrawBlock(block);
            }

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
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x, y, z + 1);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x, y + 1, z + 1);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 1, y + 1, z + 1);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 1, y, z + 1);

            //Face 2 (Back)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x + 1, y, z);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x + 1, y + 1, z);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x, y + 1, z);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x, y, z);

            //Face 3 (Left)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x, y, z);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x, y + 1, z);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x, y + 1, z + 1);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x, y, z + 1);

            //Face 4 (Right)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x + 1, y, z + 1);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x + 1, y + 1, z + 1);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 1, y + 1, z);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 1, y, z);

            //Face 5 (Top)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x, y + 1, z + 1);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x, y + 1, z);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 1, y + 1, z);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 1, y + 1, z + 1);

            //Face 6 (Bottom)
            GL.TexCoord2(textureLeft, textureBottom);  GL.Vertex3(x, y, z);
            GL.TexCoord2(textureLeft, textureTop);     GL.Vertex3(x, y, z + 1);
            GL.TexCoord2(textureRight, textureTop);    GL.Vertex3(x + 1, y, z + 1);
            GL.TexCoord2(textureRight, textureBottom); GL.Vertex3(x + 1, y, z);

            GL.End();
		}
		
		public static void Create() 
		{
			using(RenderWindow renderWindow = new RenderWindow("Aggrocube", 800, 600))
            {
                renderWindow.Run(30.0);
            }
		}
	}
}

