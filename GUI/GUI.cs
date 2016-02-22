using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BasicGUI
{
    public static class GUI
    {
         static SpriteFont font;
         static string text;
         static Vector2 position;
         static SpriteBatch batch;
         static Rectangle r;
         static Rectangle mouseRect;

        static GUI()
        {
            font = GUISetup.ContentDevice.Load<SpriteFont>("Ubuntu-B");
          //  texture = Setup.ContentDevice.Load<Texture2D>("bar");
        }        

        public static void Init(SpriteBatch spriteBatch, Rectangle _mouseRect)
        {
            mouseRect = _mouseRect;
            batch = spriteBatch;

            GUILayout.Init(spriteBatch, _mouseRect);
        }

        public static void Label(Rectangle rect, string t)
        {
            Color color = Color.White;
            position = new Vector2(rect.X, rect.Y);
            text = t;
            batch.DrawString(font, text, position, color);
        }

        public static void Box(Rectangle rect, string t)
        {
            Color color = Color.White;
            Texture2D texture = GUISetup.ContentDevice.Load<Texture2D>("blue_panel"); 
            text = t;
            position = new Vector2(rect.Location.X + rect.Width/2f - font.MeasureString(t).X / 2f, rect.Location.Y + rect.Height/2f - font.MeasureString(t).Y / 2f);
            batch.Draw(texture, rect, Color.White);
            batch.DrawString(font, text, position, color);
        }

        public static bool Button(Rectangle rect, string t)
        {
            Color color = Color.White;
            Texture2D texture_normal = GUISetup.ContentDevice.Load<Texture2D>("blue_button_normal");
            Texture2D texture_press = GUISetup.ContentDevice.Load<Texture2D>("blue_button_press");
            text = t;
            position = new Vector2(rect.Location.X + rect.Width / 2f - font.MeasureString(t).X / 2f, rect.Location.Y + rect.Height / 2f - font.MeasureString(t).Y / 2f);
               
             if (mouseRect.Intersects(rect))
            {
                color = Color.Red;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    batch.Draw(texture_press, rect, Color.White);

                    if (mouseRect.Intersects(rect) && Mouse.GetState().LeftButton == ButtonState.Pressed && GUISetup.LastMouseState.LeftButton != ButtonState.Pressed)
                    {
                        batch.Draw(texture_press, rect, Color.White);
                        batch.DrawString(font, text, position, color);
                        return true;
                    }
                }
                else
                {
                    batch.Draw(texture_normal, rect, Color.White);
                }
              
                batch.DrawString(font, text, position, color);
                return false;
            }
            else
            {
                color = Color.White;
                batch.Draw(texture_normal, rect, Color.White);
                batch.DrawString(font, text, position, color);
                return false;
            }
        }


   
        public static Vector2 Size
        {
            get
            {
                return font.MeasureString(text);
            }
        }

        public static void Load(string path)
        {
            font = GUISetup.ContentDevice.Load<SpriteFont>(path);
        }

    }

}
