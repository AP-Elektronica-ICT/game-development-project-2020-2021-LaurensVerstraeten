using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Animation.ShadowAnimation
{
    class JumpAnimation : IAnimation
    {
        private Animatie _animatie;
        public Texture2D texture;
        public Vector2 position;
        public Animatie animatie { get { return _animatie; } set { _animatie = value; } }

        public JumpAnimation(Texture2D texture, Vector2 Position)
        {
            this.position = Position;
            this.texture = texture;
            _animatie = new Animatie();
            _animatie.AddFrame(new AnimationFrame(new Rectangle(0, 82, 35, 37)));            
        }
        public void draw(SpriteBatch spriteBatch, Vector2 _position, SpriteEffects flip)
        {
            this.position = _position;
            spriteBatch.Draw(this.texture, new Rectangle((int)position.X, (int)position.Y, Global.shadowScale, Global.shadowScale), _animatie.currentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), flip, 0);
        }

        public void update(GameTime gameTime)
        {
            animatie.Update(gameTime);
        }
    }
}
