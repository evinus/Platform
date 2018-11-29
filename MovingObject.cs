using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Platform
{
    class MovingObject : GameObject
    {
        protected Rectangle drawPos;
        protected float rotation = 0;
        protected int currentFrame = 0;
        protected float timeSinceLastFrame;
        protected int numberOfFrames;
        protected float timeBetweenFrames = 0.1f;
        protected int offset;
        protected GameManager gm;
        protected Vector2 speed = new Vector2(0, 0);
        protected bool falling;

        public MovingObject(Texture2D texMain, Rectangle pos, GameManager gm) : base(texMain, pos)
        {
            drawPos = new Rectangle(0, 0, pos.Width, pos.Height);
            this.gm = gm;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            drawPos.X = position.X + offset;
            drawPos.Y = position.Y + offset;
            
        }

        protected virtual void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceLastFrame >= timeBetweenFrames)
            {
                timeSinceLastFrame = 0;
                currentFrame++;
                if (currentFrame >= numberOfFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        protected void CheckCollision()
        {
            foreach (var item in gm.gameObjects)
            {
                if (item == this) continue;

                if(position.Intersects(item.position))
                {
                    if(position.Left > item.position.Right)
                    {
                        speed.X = 0;
                        position.X = item.position.Right + 1;
                    }
                    else if(position.Right < item.position.Left)
                    {
                        speed.X = 0;
                        position.X = item.position.Left - 1;
                    }
                    else if(position.Bottom > item.position.Top)
                    {
                        speed.Y = 0;
                        position.Y = item.position.Top - position.Height;
                        falling = false;
                    }
                    else if(position.Top < item.position.Bottom)
                    {
                        speed.Y = 0;
                        position.Y = item.position.Bottom + 1;
                    }
                }
            }
        }
    }
}