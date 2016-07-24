using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GrumpyGorillaNotShit
{
    /*
     * Entity Manager Class
     *      Takes care of loading various items, enemies and the character
     */
    class EntityManager
    {
        List<Enemy_Gibbon> enemies = new List<Enemy_Gibbon>();
        List<Item_HSP> snackpacks = new List<Item_HSP>();
        Character gorilla; // Greg
        Texture2D hsp_texture;
        Random rnd = new Random();
        int enemycount;
        float window_x, window_y;
        public void LoadEntities(GraphicsDeviceManager graphics, ContentManager content)
        {
            hsp_texture = content.Load<Texture2D>("sprite_hsp.png");
            gorilla = new Character(content, 10, 10);
            enemycount = rnd.Next(10) + 1;
            window_x = graphics.PreferredBackBufferWidth;
            window_y = graphics.PreferredBackBufferHeight;
            for (int i = 0; i < enemycount; i++)
            {
                Enemy_Gibbon current = new Enemy_Gibbon(content, graphics);
                current.sprite.Levels = 1;
                current.sprite.Frames = 4;
                enemies.Add(current);
            }
            snackpacks = load_snackpacks(hsp_texture);
            
        }
        public void UpdateEntities()
        {
            gorilla.UpdateCharacter();
            if (gorilla.exit_status != exit_type.Not)
                snackpacks = load_snackpacks(hsp_texture);
            foreach (var h in snackpacks)
                h.UpdateHSP();
            foreach (var e in enemies)
                e.UpdateEnemy();
        }
        public void DrawEntities(SpriteBatch spriteBatch)
        {
            gorilla.DrawCharacter(spriteBatch);
            foreach (var e in enemies)
                e.DrawEnemy(spriteBatch);
            foreach (var h in snackpacks)
                h.DrawHSP(spriteBatch);
        }
        public List<Item_HSP> load_snackpacks(Texture2D texture)
        {
            var hsp_list = new List<Item_HSP>();
            for (int i = 0; i < rnd.Next(50); i++) // HSPs
            {
                var hsp = new Item_HSP(texture, new Vector2((float)rnd.Next(800 - 35), (float)rnd.Next(600 - 50)));
                hsp_list.Add(hsp);
            }
            return hsp_list;
        }
    }
}
