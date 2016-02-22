using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BasicGUI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rectangle mouseRect;
        Vector2 mousePos;
        Texture2D mouseTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Setup.Init(Content, graphics);
           //  graphics.PreferredBackBufferHeight = 720;
            //  graphics.PreferredBackBufferWidth = 1280;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Mouse.WindowHandle = Window.Handle;
            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2 + Window.Position.X, GraphicsDevice.Viewport.Height / 2 + Window.Position.Y);
            this.IsMouseVisible = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mouseTexture = Content.Load<Texture2D>("mouse_32");

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


           // Console.WriteLine(mousePos + " - " + graphics.GraphicsDevice.Viewport.Width);



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        void OnGUI(SpriteBatch spriteBatch)
        {
            GUI.Init(spriteBatch);
            GUI.Text(new Rectangle(0, 0, 0, 0), "Test");
            GUI.Text(new Rectangle(15, 200, 0, 0), "WOW !");
            GUI.Box(new Rectangle(500, 150, 100, 100), "BOOOX !");
            if (GUI.Button(new Rectangle(100, 15, 100, 50), "Button !", mouseRect) && Mouse.GetState().LeftButton == ButtonState.Pressed)
               Console.WriteLine("YEEEEEEEEEEEEAAAAH!");

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mouseRect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 0, 0);
            mousePos = new Vector2(Mouse.GetState().X - Window.Position.X - mouseTexture.Width/2, Mouse.GetState().Y - Window.ClientBounds.Top);

            spriteBatch.Begin();
            OnGUI(spriteBatch);
            spriteBatch.Draw(mouseTexture, mousePos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
