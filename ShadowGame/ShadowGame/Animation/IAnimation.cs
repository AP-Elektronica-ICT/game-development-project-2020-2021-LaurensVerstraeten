using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Animation
{
    interface IAnimation
    {
        public Animatie animatie { get; set; }
        public void draw(SpriteBatch spriteBatch, Vector2 _position, SpriteEffects flip);
        public void update(GameTime gameTime);
        

    }
}
