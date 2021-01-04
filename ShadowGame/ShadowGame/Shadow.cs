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
    public class Shadow : IGameObject //ITransform
    {
        private Texture2D shadowTexture;
        private Vector2 position;
        public Vector2 velocity;
        private string directionBefore;
        public Vector2 direction;
        public Vector2 Position
        {
            get { return position; }
        }

        //public Rectangle CollisionRectangle { get; set; }
        private Rectangle Hitbox;
        private Rectangle FutureHitbox;
        public bool hasJumped = false;

        IInputReader inputReader;
        IAnimation walkRight;
        IAnimation walkLeft;
        IAnimation leftIdle;
        IAnimation rightIdle;
        IAnimation currentAnimation;

        //private IGameCommand moveCommand;

        public Shadow(Texture2D texture, IInputReader reader)
        {
            position = new Vector2(50, 0);
            shadowTexture = texture;
            walkRight = new RightAnimation(texture, position);
            walkLeft = new LeftAnimation(texture, position);
            leftIdle = new LeftIdleAnimation(texture, position);
            rightIdle = new RightIdleAnimation(texture, position);
            currentAnimation = rightIdle;

            //Read input for my shadow class
            this.inputReader = reader;

            //moveCommand = new MoveCommand();

            //startpositie
            //position = new Vector2(0, 0);
            
            Hitbox = new Rectangle((int)position.X, (int)position.Y, 55, 55);
            FutureHitbox = new Rectangle((int)position.X, (int)position.Y, 55, 55);

            Global.moveCommand.Context(this);
        }

        public void Update(GameTime gameTime)
        {
            direction = inputReader.ReadInput(hasJumped);
            

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
            Move(direction, gameTime);
            Debug.WriteLine(velocity);
            position += velocity;

            //Global.moveCommand.GiveRectangleColBox(Hitbox);
            currentAnimation.update(gameTime);
            //Debug.WriteLine(Hitbox);
            //Debug.WriteLine(FutureHitbox);
            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;            
        }

        private void Move(Vector2 _direction, GameTime gameTime)
        {
            if (_direction.X == 1)
            {
                currentAnimation = walkRight;
                FutureHitbox.X = (int)position.X + 1;
                directionBefore = "right";
            }
            if (_direction.X == -1)
            {
                currentAnimation = walkLeft;
                FutureHitbox.X = (int)position.X - 1;
                directionBefore = "left";
            }
            if (_direction.X == 0)
            {
                if (directionBefore == "right")
                {
                    currentAnimation = rightIdle;
                }
                if (directionBefore == "left")
                {
                    currentAnimation = leftIdle;
                }
            }                    

            //if (_direction.Y == -5)
            //{
            //    FutureHitbox.Y = (int)Position.Y - 1;
            //    Debug.WriteLine("jump");
            //}

            //Debug.WriteLine(_direction);
            //Debug.WriteLine(FutureHitbox);
            //moveCommand.Execute(this, _direction);
            Global.moveCommand.Execute();
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (Hitbox.TouchTopOF(newRectangle))
            {
                position.Y = newRectangle.Y - Hitbox.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (Hitbox.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - Hitbox.Width - 2;
            }

            if (Hitbox.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 2;
            }

            if (Hitbox.TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - Hitbox.Width) position.X = xOffset - Hitbox.Width;
            if (position.Y < 0) velocity.Y = 1f;
            //if (position.Y > yOffset - Hitbox.Height) position.Y = yOffset - Hitbox.Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.draw(spriteBatch, position);
        }


    }
}
