using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.World
{
    class Coin
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        public bool isCollected = false;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public Coin(Rectangle newRectangle)
        {
            texture = Global.Content.Load<Texture2D>("coin");
            this.Rectangle = newRectangle;
        }
        
        public void Update()
        {
            if (isCollected)
            {
                this.Rectangle = new Rectangle(-100, -100, 0, 0);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isCollected)
            {
                spriteBatch.Draw(texture, rectangle, Color.White);
            }      
            
        }
    }
}
