using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoLibrary;

namespace Platform
{
    public class GameManager : IGame
    {
        public List<GameObject> gameObjects { get; private set; } = new List<GameObject>();
        Player player;

        public GameManager()
        {
              
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in gameObjects)
            {
                item.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in gameObjects)
            {
                item.Update(gameTime);
            }
        }

        private void CheckCollisions()
        {
            foreach (var item in gameObjects)
            {
                if (item == player) continue;

                if(player.position.Intersects(item.position))
                {
                    

                }
            }
        }
    }
}
