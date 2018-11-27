﻿using System;
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
            JumpFalling();
            CheckGround();
        }

        private void JumpFalling()
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
            if (falling == false)
            {
                foreach (var item in gm.gameObjects)
                { // kollar om man står på ett object
                    if (position.Bottom + 1 == item.position.Top && item != this)
                    {//kollar om man är höger 
                        if (position.Left > item.position.Right)
                        {
                            foreach (var other in gm.gameObjects)
                            {//kollar om det finns ett annat object 
                                if (other.position.Contains(position.Left - 1, position.Bottom + 1) && other != this && item != other)
                                {
                                    //falling = false;
                                }
                                else
                                {
                                    falling = true;
                                    return;
                                }
                            }
                        }
                        else if (position.Right < item.position.Left)
                        {
                            foreach (var other in gm.gameObjects)
                            {
                                if(other.position.Contains(position.Right +1,position.Bottom +1) && other != this && item != other)
                                {
                                    //falling = false;
                                }
                                else
                                {
                                    falling = true;
                                    return;
                                }
                            }
                        }

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
