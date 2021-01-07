using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Animation.ShadowAnimation
{
    class RightIdleAnimation : IAnimation
    {
        private Animatie _animatie;
        public Texture2D texture;
        public Vector2 position;
        public Animatie animatie { get { return _animatie; } set { _animatie = value; } }
        public RightIdleAnimation(Texture2D texture, Vector2 Position)
        {
            this.position = Position;
            this.texture = texture;
            _animatie = new Animatie();
            _animatie.AddFrame(new AnimationFrame(new Rectangle(0, 41, 42, 37)));
        }
        public void draw(SpriteBatch spriteBatch, Vector2 _position)
        {
            this.position = _position;
            spriteBatch.Draw(this.texture, new Rectangle((int)position.X, (int)position.Y, 42, 42), _animatie.currentFrame.SourceRectangle, Color.White);
        }

        public void update(GameTime gameTime)
        {
            _animatie.Update(gameTime);
        }
    }
}
