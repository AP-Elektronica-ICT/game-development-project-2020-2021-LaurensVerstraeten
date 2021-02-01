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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
