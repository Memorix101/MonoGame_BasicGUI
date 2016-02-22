using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BasicGUI
{
    public static class GUISetup
    {
        private static ContentManager c;
        private static GraphicsDeviceManager g;
        private static MouseState lastMouseState;

        public static void Init(ContentManager _content, GraphicsDeviceManager _graphics, Game game, MouseState mouse)
        {
            lastMouseState = mouse;
            g = _graphics;
            c = _content;
            Mouse.WindowHandle = game.Window.Handle;
            Mouse.SetPosition(_graphics.GraphicsDevice.Viewport.Width / 2 - game.Window.Position.X / 2, _graphics.GraphicsDevice.Viewport.Height / 2 - game.Window.Position.Y / 2);
        }

        public static ContentManager ContentDevice
        {
            get
            {
                return c;
            }
        }

        public static GraphicsDeviceManager graphics
        {
            get
            {
                return g;
            }
        }

        public static MouseState LastMouseState
        {
            set
            {
                lastMouseState = value;
            }
            get
            {
                return lastMouseState;
            }
        }
    }
}
