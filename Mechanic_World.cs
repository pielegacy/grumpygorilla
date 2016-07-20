using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrumpyGorillaNotShit
{
    /*
     *  Mechanic_World Class 
     *      Used for generating the world the gorilla is to roam around and such
     *      Takes in size and location Variables for extra customisation
     */
    class Mechanic_World
    {
        public Vector2 current_location;
        public Vector2 world_size;

        public Mechanic_World(Vector2 size, Vector2 start_location)
        {
            if (size == null)
                world_size = new Vector2(10, 10);
            else
                world_size = size;
            if (start_location == null)
                current_location = new Vector2(0, 0);
            else
                current_location = start_location;
        }
        public void Update_World(Character character)
        {
            bool moved = false;
            switch (character.exit_status)
            {
                case exit_type.North:
                    character.sprite.Location.Y = 500;
                    current_location.Y -= 1;
                    moved = true;
                    break;
                case exit_type.East:
                    character.sprite.Location.X = 10;
                    current_location.X += 1;
                    moved = true;
                    break;
                case exit_type.South:
                    character.sprite.Location.Y = 10;
                    current_location.Y += 1;
                    moved = true;
                    break;
                case exit_type.West:
                    character.sprite.Location.X = 700;
                    current_location.X -= 1;
                    moved = true;
                    break;
            }
            if (moved) {
                character.exit_status = exit_type.Not;
                Console.WriteLine(current_location.ToString());
            }
            
            
        }   
    }
}
