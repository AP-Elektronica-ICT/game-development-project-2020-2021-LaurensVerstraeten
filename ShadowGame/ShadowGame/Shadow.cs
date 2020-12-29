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
using System.Diagnostics;
using System.Text;

namespace ShadowGame
{
    public class Shadow : IGameObject, ITransform
    {
        private Texture2D shadowTexture;
        public Vector2 Position { get; set; }
        //public Rectangle CollisionRectangle { get; set; }
        private Rectangle Hitbox;
        private Rectangle FutureHitbox;

        IInputReader inputReader;
        IAnimation walkRight;
        IAnimation walkLeft;
        IAnimation idle;
        IAnimation currentAnimation;

        //private IGameCommand moveCommand;

        public Shadow(Texture2D texture, IInputReader reader)
        {
            
            shadowTexture = texture;
            walkRight = new RightAnimation(texture, this);
            walkLeft = new LeftAnimation(texture, this);
            //idle = new IdleAnimation();
            currentAnimation = walkRight;

            //Read input for my shadow class
            this.inputReader = reader;

            //moveCommand = new MoveCommand();

            Position = new Vector2(20, 0);

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 55, 55);
            FutureHitbox = new Rectangle((int)Position.X, (int)Position.Y, 55, 55);

        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();

            Move(direction);
            //Global.moveCommand.GiveRectangleColBox(Hitbox);
            currentAnimation.update(gameTime);
            Debug.WriteLine(Hitbox);
            Debug.WriteLine(FutureHitbox);
            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;            
        }

        private void Move(Vector2 _direction)
        {
            if (_direction.X == 1)
            {
                currentAnimation = walkRight;
                FutureHitbox.X = (int)Position.X + 1;
            }
            if (_direction.X == -1)
            {
                currentAnimation = walkLeft;
                FutureHitbox.X = (int)Position.X - 1;
            }
            if (_direction.X == 0)
            {
                //FutureHitbox.X = 0;
            }
            //moveCommand.Execute(this, _direction);
            Global.moveCommand.Execute(this, _direction, FutureHitbox);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.draw(spriteBatch);
        }


    }
}
