using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GrumpyGorillaNotShit
{
    class Sprite
    {
        public Texture2D Texture { get; set; }
        public int Frames { get; set; }
        public int Levels { get; set; }
        public bool IsAnimated { get; set; }
        public int CurrentFPS = 0;
        public int MaxFPS = 5;
        public Vector2 Location = new Vector2(0, 0);
        public int CurrentFrame { get; set; }
        public int CurrentLevel { get; set; }

        public Sprite(Texture2D texture, int frames, int levels, float x, float y)
        {
            Texture = texture;
            Frames = frames;
            Levels = levels;
            IsAnimated = true;
            Location = new Vector2(x, y);
            CurrentFrame = 0;
            CurrentLevel = 0;
        }
        public void Update()
        {
            CurrentFPS++;
            if (CurrentFPS > MaxFPS)
            {
                CurrentFPS = 0;
                if (IsAnimated)
                {
                    CurrentFrame++;
                    if (CurrentFrame >= Frames)
                    {
                        CurrentFrame = 0;
                    }
                }
                else
                {
                    CurrentFrame = 0;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int Width = Texture.Width / Frames;
            int Height = Texture.Height / Levels;
            Rectangle Source = new Rectangle(Width * CurrentFrame, Height * CurrentLevel, Width, Height);
            Rectangle Output = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Output, Source, Color.White);
            spriteBatch.End();
        }
    }
}
