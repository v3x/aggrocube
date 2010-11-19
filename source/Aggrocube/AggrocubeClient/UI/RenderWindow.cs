using System;
using OpenTK;
using OpenTK.Graphics;

namespace AggrocubeClient.UI
{
	public class RenderWindow : GameWindow
	{
		public RenderWindow() : base(800, 600, GraphicsMode.Default, "Aggrocube")
		{
		}
	}
}

