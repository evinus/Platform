using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Platform
{
    public class LevelManager :IGame
    {
        public Map Map { get; private set; } = new Map();

        string mapFileName;
        GameManager gm;
        public LevelManager(GameManager gm)
        {
            this.gm = gm;
           
        }



        private void LoadMap()
        {
            try
            {
                using (FileStream filestream = new FileStream(mapFileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    StreamReader reader = new StreamReader(filestream);
                    int currentLine = 0;

                    while (reader.EndOfStream == false)
                    {
                        string line = reader.ReadLine();
                        if(currentLine == 0)
                        {

                        }
                        string[] lineSplit = line.Split(';');
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SaveMap()
        {
            try
            {
                using (FileStream filestream = new FileStream(mapFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    StreamWriter writer = new StreamWriter(filestream);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
        }
    }
}
