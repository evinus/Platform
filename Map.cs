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
    public class Map : IGame
    {
        List<Enemy> enemies = new List<Enemy>();
        public List<StationaryObject> Stationaries { get; } = new List<StationaryObject>();
        List<Rectangle> rectangles { get; } = new List<Rectangle>();

        public Map()
        {
            Start();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assetmanager.TexGround1, Stationaries[0].position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
           
        }

        private void Start()
        {
            Rectangle rec = new Rectangle(0, 300, 100, 50);
     
            StationaryObject stationary = new StationaryObject(Assetmanager.TexGround1, rec);
            Stationaries.Add(stationary);
        }
    }
}
