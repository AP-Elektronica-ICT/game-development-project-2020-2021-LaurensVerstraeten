﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowGame.Animation.ShadowAnimation;
using ShadowGame.Collision;
using ShadowGame.Input;
using ShadowGame.LevelDesign;
using ShadowGame.World;
using ShadowGame.Menu;
using System;
using System.Diagnostics;

namespace ShadowGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private States _currentState;
        private States _nextState;

        public void ChangeState(States state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1275;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {            
            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
                       
            // TODO: use this.Content to load your game content here
        }
                
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
                        
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Global.spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
            GraphicsDevice.Clear(Color.BurlyWood);

            // TODO: Add your drawing code here
            _currentState.Draw(gameTime, Global.spriteBatch);
                        

            base.Draw(gameTime);
        }        
 
    }

}
