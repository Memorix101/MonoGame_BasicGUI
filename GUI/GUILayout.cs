﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BasicGUI
{
    struct AreaLayout
    {
        public AreaLayout(Rectangle r) { rect = r; elements = 0; }
        public Rectangle rect;
        public int elements;
    }

    public static class GUILayout
    {
        static SpriteFont font;
        static string text;
        static Vector2 position;
        static SpriteBatch batch;
        static Rectangle mouseRect;
        //static float _offset;
        static float _offset = 20; //default height 20 //AreaStack.Peek().rect.Height
        static int size = 30;

        static Stack<AreaLayout> AreaStack = new Stack<AreaLayout>();

        static GUILayout()
        {
            font = GUISetup.ContentDevice.Load<SpriteFont>("Ubuntu-B");
            //  texture = Setup.ContentDevice.Load<Texture2D>("bar");
        }

        public static void Init(SpriteBatch spriteBatch, Rectangle _mouseRect)
        {
            mouseRect = _mouseRect;
            batch = spriteBatch;
        }

        public static void BeginArea(Rectangle rect)
        {
            AreaStack.Push(new AreaLayout(rect));
        }

        public static void EndArea()
        {
            AreaStack.Pop();
        }

        public static void Label(string t)
        {
            Color color = Color.White;

            position = new Vector2(AreaStack.Peek().rect.X, AreaStack.Peek().rect.Y + AreaStack.Peek().elements * _offset);
            AreaLayout layout = AreaStack.Pop();
            layout.elements++;
            AreaStack.Push(layout);

            text = t;
            batch.DrawString(font, text, position, color);
        }

        public static void Space(int space)
        {
            Color color = Color.White;

            for (int i = 0; i < space; i++)
            {
                position = new Vector2(AreaStack.Peek().rect.X, AreaStack.Peek().rect.Y + AreaStack.Peek().elements * _offset);
                AreaLayout layout = AreaStack.Pop();
                layout.elements++;
                AreaStack.Push(layout);
            }

            text = " ";
            //batch.DrawString(font, text, position, color);
        }

        public static void Box(string t)
        {
            Color color = Color.White;
            Texture2D texture = GUISetup.ContentDevice.Load<Texture2D>("blue_panel");
            text = t;

            position = new Vector2(AreaStack.Peek().rect.Location.X + AreaStack.Peek().rect.Width / 2f - font.MeasureString(t).X / 2f,
            AreaStack.Peek().rect.Location.Y + size / 2f - font.MeasureString(t).Y / 2f + AreaStack.Peek().elements * _offset);

            Rectangle rectPos = new Rectangle(AreaStack.Peek().rect.Location.X, AreaStack.Peek().rect.Location.Y + AreaStack.Peek().elements * (int)_offset,
            AreaStack.Peek().rect.Width, size);

            AreaLayout layout = AreaStack.Pop();
            layout.elements++;
            AreaStack.Push(layout);

            batch.Draw(texture, rectPos, Color.White);
            batch.DrawString(font, text, position, color);
        }

        public static bool Button(string t)
        {
            Color color = Color.White;
            Texture2D texture_normal = GUISetup.ContentDevice.Load<Texture2D>("blue_button_normal");
            Texture2D texture_press = GUISetup.ContentDevice.Load<Texture2D>("blue_button_press");

            text = t;

            position = new Vector2(AreaStack.Peek().rect.Location.X + AreaStack.Peek().rect.Width / 2f - font.MeasureString(t).X / 2f,
                 AreaStack.Peek().rect.Location.Y + size / 2f - font.MeasureString(t).Y / 2f + AreaStack.Peek().elements * _offset);

            Rectangle rectPos = new Rectangle(AreaStack.Peek().rect.Location.X, AreaStack.Peek().rect.Location.Y + AreaStack.Peek().elements * (int)_offset,
                AreaStack.Peek().rect.Width, size);

            AreaLayout layout = AreaStack.Pop();
            layout.elements++;
            AreaStack.Push(layout);

            if (mouseRect.Intersects(rectPos))
            {
                color = Color.Red;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    batch.Draw(texture_press, rectPos, Color.White);

                    if (mouseRect.Intersects(rectPos) && Mouse.GetState().LeftButton == ButtonState.Pressed && GUISetup.LastMouseState.LeftButton != ButtonState.Pressed)
                    {
                        batch.Draw(texture_press, rectPos, Color.White);
                        batch.DrawString(font, text, position, color);
                        return true;
                    }
                }
                else
                {
                    batch.Draw(texture_normal, rectPos, Color.White);
                }

                batch.DrawString(font, text, position, color);
                return false;
            }
            else
            {
                color = Color.White;
                batch.Draw(texture_normal, rectPos, Color.White);
                batch.DrawString(font, text, position, color);
                return false;
            }
        }

        public static void Load(string path)
        {
            font = GUISetup.ContentDevice.Load<SpriteFont>(path);
        }
    }
}