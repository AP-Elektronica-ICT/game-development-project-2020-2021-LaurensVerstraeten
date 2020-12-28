using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowGame.Animation;
using ShadowGame.Animation.ShadowAnimation;
using ShadowGame.Collision;
using ShadowGame.Command;
using ShadowGame.Input;
using ShadowGame.Interfaces;
using ShadowGame.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame
{
    public class Shadow : IGameObject, ITransform
    {
        private Texture2D shadowTexture;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

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

            //Read input for my shadow class
            this.inputReader = reader;

            moveCommand = new MoveCommand();

            Position = new Vector2(0, 0);

            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 55, 55);

        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();

            Move(direction);
            moveCommand.GiveRectangleColBox(_collisionRectangle);
            currentAnimation.update(gameTime);
            
            _collisionRectangle.X = (int)Position.X;
            _collisionRectangle.Y = (int)Position.Y;            
        }

        private void Move(Vector2 _direction)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.draw(spriteBatch);
        }


    }
}
