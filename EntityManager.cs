using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GrumpyGorillaNotShit
{
    class EntityManager
    {
        List<Enemy_Gibbon> enemies = new List<Enemy_Gibbon>();
        Random rnd = new Random();
        int enemycount;
        float window_x, window_y;
        public void LoadEntities(GraphicsDeviceManager graphics, ContentManager content)
        {
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
        }
        public void UpdateEntities()
        {
            foreach (var e in enemies)
                e.UpdateEnemy();
        }
        public void DrawEntities(SpriteBatch spriteBatch)
        {
            foreach (var e in enemies)
                e.DrawEnemy(spriteBatch);
        }
    }
}
