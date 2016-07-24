using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrumpyGorillaNotShit
{
    class Item_HSP
    {
        private Texture2D hsp_texture;
        public Sprite sprite;
        public Vector2 hsp_location;
        private Random rand = new Random();
        public Item_HSP(Texture2D hsp_texture, Vector2 location)
        {
            hsp_location = location;
            sprite = new Sprite(hsp_texture, 1, 1, hsp_location.X, hsp_location.Y);
        }
        public void UpdateHSP()
        {
            sprite.Update();
        }
        public void DrawHSP(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
