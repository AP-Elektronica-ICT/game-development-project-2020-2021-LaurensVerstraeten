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
    public class Shadow : IGameObject
    {
        private Texture2D shadowTexture;
        private Vector2 position;
        public Vector2 velocity;
        //public bool isFalling = false;
        private Vector2 directionLooking = new Vector2(1, 0);
        public Vector2 direction;
        public Vector2 Position
        {
            get { return position; }
        }

        //public Rectangle CollisionRectangle { get; set; }
        private Rectangle Hitbox;
        public bool hasJumped;

        IInputReader inputReader;        
        IAnimation currentAnimation;
        IAnimation idle;
        IAnimation walk;
        IAnimation jump;
        //IAnimation falling;
        
        //private IGameCommand moveCommand;

        public Shadow(Texture2D texture, IInputReader reader)
        {
            position = new Vector2(50, 0);
            shadowTexture = texture;            
            walk = new WalkAnimation(texture, position);
            idle = new IdleAnimation(texture, position);
            jump = new JumpAnimation(texture, position);
            //falling = new FallingAnimation(texture, position);
            currentAnimation = idle;

            //Read input for my shadow class
            this.inputReader = reader;

            //moveCommand = new MoveCommand();

            //startpositie
            //position = new Vector2(0, 0);
            
            Hitbox = new Rectangle((int)position.X, (int)position.Y, Global.shadowScale, Global.shadowScale);
            //FutureHitbox = new Rectangle((int)position.X, (int)position.Y, 42, 42);

            Global.moveCommand.Context(this);
            Global.jumpCommand.Context(this);
        }

        public void Update(GameTime gameTime)
        {
            direction = inputReader.ReadInput(hasJumped);
            float secondsElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (velocity.Y < 10)
            {
                velocity.Y += 20f * secondsElapsed;                
            }
            
            Move(direction, gameTime);
            //Debug.WriteLine(velocity);
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
                currentAnimation = walk;
                directionLooking.X = 1;
            }
            if (_direction.X == -1)
            {
                currentAnimation = walk;
                directionLooking.X = -1;
            }
            if (_direction.X == 0)
            {
                currentAnimation = idle;                
            }

            Global.moveCommand.Execute();
            
            if (hasJumped == true)
            {
                currentAnimation = jump;                
            }
            
            if (_direction.Y == -7.8f)
            {                
                Global.jumpCommand.Execute();
            }                      
            
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
            SpriteEffects flip = SpriteEffects.None;
            if (directionLooking.X == -1)
            {
                flip = SpriteEffects.FlipHorizontally;
            }
            currentAnimation.draw(spriteBatch, position, flip);
        }
    }
}
