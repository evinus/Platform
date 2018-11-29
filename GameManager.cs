using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Platform
{
    public class GameManager 
    {
        public List<GameObject> gameObjects { get; private set; } = new List<GameObject>();
        Player player;
        LevelManager levelManager;

        public GameManager()
        {
            levelManager = new LevelManager(this);
            player = new Player(Assetmanager.TexPlayer, new Rectangle(0, 0, 50, 70), this);
            foreach (var item in levelManager.Map.Stationaries)
            {
                gameObjects.Add(item);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in gameObjects)
            {
                item.Draw(spriteBatch);
            }
            levelManager.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in gameObjects)
            {
                item.Update(gameTime);
            }
            player.Update(gameTime);
        }

        
    }
}
