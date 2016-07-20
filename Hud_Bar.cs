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
    // Hud Class
    class Hud_Bar
    {
        public Sprite sprite_bar;
        private Texture2D bar_texture;
        private Texture2D bar_fill_texture;
        private hud_type bar_type { get; set; }
        private float gorilla_speed = 4f; // Default speed
        private bool gorilla_ismoving = false;
        private double gorilla_hunger = 100;

        public Hud_Bar(ContentManager content, float bar_pos, hud_type type)
        {
            bar_texture = content.Load<Texture2D>("hud_bar.png");
            sprite_bar = new Sprite(bar_texture, 1, 1, 20, bar_pos * 10);
            bar_type = type;
            Color bar_color;
            switch (type)
            {
                case hud_type.Hunger:
                    bar_color = Color.Brown;
                    break;
                case hud_type.Stamina:
                    break;
                case hud_type.Halal_Certification:
                    break;
                default:
                    bar_color = Color.Red;
                    break;
            }
            //bar_fill_texture = content.Load<Texture2D>
        }
        public void UpdateHud() {

            sprite_bar.Update(); 
        }
        public void DrawHud(SpriteBatch spriteBatch)
        {
            sprite_bar.Draw(spriteBatch);
        }

    }
}
