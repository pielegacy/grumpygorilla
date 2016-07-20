using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GrumpyGorillaNotShit
{
    // Container for da enemy man
    class Enemy_Gibbon
    {
        public Sprite sprite;
        private Texture2D enemy_texture;
        private Random rand = new Random();
        //private KeyboardState currentKeys, prevKeys;
        private float enemy_speed = 2.0f; // Default speed
        private bool enemy_ismoving = false;
        private Vector2 bounds;

        public Enemy_Gibbon(ContentManager content, GraphicsDeviceManager graphics)
        {
            bounds = new Vector2((float)graphics.PreferredBackBufferWidth, (float)graphics.PreferredBackBufferHeight);
            enemy_texture = content.Load<Texture2D>("sprite_enemy_gibbon.png");
            sprite = new Sprite(enemy_texture, 4, 2, 0, 0);
            Respawn();
        }
        public void UpdateEnemy()
        {
            sprite.Location.X += enemy_speed;
            if (sprite.Location.X + 10 > bounds.X)
                Respawn();
            sprite.Update(); 
        }
        public void DrawEnemy(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public void Respawn()
        {
            enemy_speed = rand.Next(5, 10);
            sprite.Location.Y = rand.Next(0, (int)bounds.Y);
            sprite.Location.X = 0 - rand.Next(80, 400);
        }

    }
}
