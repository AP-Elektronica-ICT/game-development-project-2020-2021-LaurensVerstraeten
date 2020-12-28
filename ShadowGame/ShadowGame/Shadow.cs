using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowGame.Animation;
using ShadowGame.Animation.ShadowAnimation;
using ShadowGame.Command;
using ShadowGame.Input;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame
{
    public class Shadow : IGameObject, ITransform
    {
        private Texture2D shadowTexture;
        private Vector2 snelheid;
        private Vector2 versnelling;
        public Vector2 Position { get; set; }

        IInputReader inputReader;
        IAnimation walkRight;
        IAnimation walkLeft;
        IAnimation currentAnimation;

        private IGameCommand moveCommand;

        public Shadow(Texture2D texture, IInputReader reader)
        {
            
            shadowTexture = texture;
            walkRight = new RightAnimation(texture, this);
            walkLeft = new LeftAnimation(texture, this);
            currentAnimation = walkRight;

            //positie = new Vector2(10, 10);
            snelheid = new Vector2(1, 1); //10 lijkt een goede snelheid voor sprite
            versnelling = new Vector2(0.1f, 0.1f);

            //Read input for my shaddow class
            this.inputReader = reader;

            moveCommand = new MoveCommand();

        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();

            MoveHorizontal(direction);

            currentAnimation.update(gameTime);
        }

        private void MoveHorizontal(Vector2 _direction)
        {
            if (_direction.X == 1)
            {
                currentAnimation = walkRight;
            }
            if (_direction.X == -1)
            {
                currentAnimation = walkLeft;
            }
            moveCommand.Execute(this, _direction);
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.draw(spriteBatch);
        }


    }
}
