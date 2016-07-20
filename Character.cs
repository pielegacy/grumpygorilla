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
    // Container for da monkey man
    class Character
    {
        public Sprite sprite;
        private Texture2D gorilla_texture;
        private KeyboardState currentKeys, prevKeys;
        private List<Hud_Bar> hud = new List<Hud_Bar>();
        private float gorilla_speed = 4f; // Default speed
        private bool gorilla_ismoving = false;
        private double gorilla_hunger = 100;

        public Character(ContentManager content, float pos_x, float pos_y)
        {
            gorilla_texture = content.Load<Texture2D>("sprite_greg_og.png");
            sprite = new Sprite(gorilla_texture, 4, 2, pos_x, pos_y);
            hud.Add(new Hud_Bar(content, 1, hud_type.Hunger));
        }
        public void UpdateCharacter() {
            prevKeys = currentKeys;
            currentKeys = Keyboard.GetState();
            if (currentKeys.IsKeyDown(Keys.Up))
                sprite.Location.Y -= gorilla_speed;
            if (currentKeys.IsKeyDown(Keys.Down))
                sprite.Location.Y += gorilla_speed;
            if (currentKeys.IsKeyDown(Keys.Left))
                sprite.Location.X -= gorilla_speed;
            if (currentKeys.IsKeyDown(Keys.Right))
                sprite.Location.X += gorilla_speed;

            if (currentKeys.IsKeyDown(Keys.Right) || currentKeys.IsKeyDown(Keys.Up) || currentKeys.IsKeyDown(Keys.Left) || currentKeys.IsKeyDown(Keys.Down))
            {
                gorilla_ismoving = true;
                sprite.CurrentLevel = 1;
            }
            else
            {
                gorilla_ismoving = false;
                sprite.CurrentLevel = 0;
            }
            foreach (var bar in hud)
                bar.UpdateHud();
            gorilla_hunger -= 0.1;
            sprite.Update(); 
        }
        public void DrawCharacter(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            foreach (var bar in hud)
                bar.DrawHud(spriteBatch);
        }

    }
}
