using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
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
        MouseState mouseState;

        SoundEffect you_win;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
       
           //graphics.PreferredBackBufferHeight = 720;
           //graphics.PreferredBackBufferWidth = 1280;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            GUISetup.Init(Content, graphics, mouseState, this);
            this.IsMouseVisible = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mouseTexture = Content.Load<Texture2D>("cursor_glossy");
            you_win = Content.Load<SoundEffect>("you_win");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        void OnGUI()
        {
            GUI.Init(spriteBatch, mouseRect);
            GUI.Label(new Rectangle(10, 10, 0, 0), "Test");
            GUI.Label(new Rectangle(15, 200, 0, 0), "WOW !");
            GUI.Box(new Rectangle(500, 150, 100, 100), "BOOOX !");

            if (GUI.Button(new Rectangle(100, 15, 100, 50), "Button !"))
            {
                you_win.Play();
                Console.WriteLine("YEEEEEEEEEEEEAAAAH!");
            }

            GUI.Box(new Rectangle(200, 150, 200, 200), " ");

            GUI.Label(new Rectangle(235, 160, 0, 0), "Stuff Inside A Box");

            if (GUI.Button(new Rectangle(250, 200, 100, 50), "In A Box !"))
            {
                you_win.Play();
                Console.WriteLine("YEEEEEEEEEEEEAAAAH!");
            }

            
            GUILayout.BeginArea(new Rectangle(250, 0, 100, 20));
            GUILayout.Label("Test1");
            GUILayout.Label("Test2");
            GUILayout.Label("Test3");
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rectangle(500, 0, 100, 20));
            GUILayout.Label("Test1");
            GUILayout.Label("Test2");
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rectangle(600, 5, 100, 50));


            if (GUILayout.Button("Button1"))
            {
                you_win.Play();
                Console.WriteLine("YEEEEEEEEEEEEAAAAH!");
            }

            GUILayout.Space(1);

            if (GUILayout.Button("Button2"))
            {
                {
                    you_win.Play();
                    Console.WriteLine("YEEEEEEEEEEEEAAAAH!");
                }
            }

            GUILayout.EndArea();
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mouseRect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 0, 0);
            mousePos = new Vector2(Mouse.GetState().X - Window.Position.X - mouseTexture.Width/2, Mouse.GetState().Y - Window.ClientBounds.Top);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            OnGUI();
            spriteBatch.Draw(mouseTexture, mousePos, Color.White);
            spriteBatch.End();

            GUISetup.LastMouseState = Mouse.GetState();

            base.Draw(gameTime);
        }
    }
}
