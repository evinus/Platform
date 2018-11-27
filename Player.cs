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
    class Player : MovingObject
    {
        
        Vector2 speed = new Vector2(0,0);
       

        public Player(Texture2D texMain, Rectangle pos, GameManager gm) : base(texMain,pos,gm)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Jump();
            CheckGround();
        }

        private void Jump()
        {
            if(KeyMouseReader.KeyPressed(Keys.Space) && falling == false)
            {
                falling = true;
                speed.Y += 3f;
            }

            if (falling == true)
            {
                speed.Y -= 0.1f;
            }
        }
        private void CheckGround()
        {
            foreach (var item in gm.gameObjects)
            {
                if(position.Bottom + 1 == item.position.Top)
                {
                    if( position.Left > item.position.Right)
                    {
                        foreach (var objects in gm.gameObjects)
                        {
                            if (objects.position.Contains(position.Left -1, position.Bottom + 1))
                            {
                                falling = false;
                            }
                            else falling = true;
                        }
                    }
                    else if( position.Right < item.position.Left)
                    {
                        
                    }
                    
                }
            }
        }
        private void CheckMoving()
        {
            if(KeyMouseReader.KeyDown(Keys.Left))
            {

            }
        }
        
    }
}
