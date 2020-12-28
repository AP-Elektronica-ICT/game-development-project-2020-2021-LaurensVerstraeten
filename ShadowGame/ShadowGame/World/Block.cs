using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.World
{
    class Block
    {
        public Texture2D _texture { get; set; }
        public Vector2 positie { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public Block(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            positie = pos;
            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 30, 30);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, CollisionRectangle, Color.AliceBlue);
        }
    }
}
