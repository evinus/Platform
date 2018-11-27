using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Platform
{
    public abstract class GameObject
    {
        protected Texture2D texMain;
        public Rectangle position;
        
        protected Rectangle source;

        public GameObject(Texture2D texMain, Rectangle pos)
        {
            this.texMain = texMain;
            this.position = pos;
        }

        public abstract void Draw(SpriteBatch spriteBatch);


        public abstract void Update(GameTime gameTime);
    }
}