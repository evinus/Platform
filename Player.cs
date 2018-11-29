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
    class Player : MovingObject
    {


        GameManager gm;

        public Player(Texture2D texMain, Rectangle pos, GameManager gm) : base(texMain,pos,gm)
        {
            this.gm = gm;
            falling = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texMain, position, Color.White);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            JumpFalling();
            CheckMoving();
            
            CheckCollision();
            position.X += (int)speed.X;
            position.Y += (int)speed.Y;
        }

        private void JumpFalling()
        {
            if(KeyMouseReader.KeyPressed(Keys.Space) && falling == false)
            {
                falling = true;
                speed.Y -= 3f;
            }

            if (falling == true)
            {
                speed.Y += 0.1f;
            }
        }
        
        private void CheckGround()
        {
            if (falling == false)
            {
                foreach (var item in gm.gameObjects)
                { 
                    if(item != this && position.Bottom +1 == item.position.Top)
                    {
                        if (position.Width < item.position.Width)
                        {
                            if (position.Right >= item.position.Left && position.Right <= item.position.Right)
                            {
                                return;
                            } 
                            else if(position.Left >= item.position.Left && position.Left <= item.position.Right)
                            {
                                return;
                            }
                        }
                        else if(position.Width > item.position.Width)
                        {
                            if(position.Left < item.position.Left && position.Right > item.position.Right)
                            {
                                return;
                            }
                        }
                    }
                }
                falling = true;
            }
        }
        private void CheckMoving()
        {
            if(KeyMouseReader.KeyDown(Keys.Left))
            {
                speed.X = -1.5f;
            }
            else
            {
                speed.X = 0;
            }
            if(KeyMouseReader.KeyDown(Keys.Right))
            {
                speed.X = 1.5f;
            }
            else
            {
                speed.X = 0;
            }
        }
        
    }
}
