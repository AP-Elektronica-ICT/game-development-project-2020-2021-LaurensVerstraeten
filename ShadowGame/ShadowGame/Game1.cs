using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowGame.Animation.ShadowAnimation;
using ShadowGame.Collision;
using ShadowGame.Input;
using ShadowGame.LevelDesign;
using ShadowGame.World;
using System;
using System.Diagnostics;

namespace ShadowGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D texture;
        Shadow shadow;
        LevelOne level;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Global.Content = Content;
            level = new LevelOne();
            level.CreateWorld(25);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("ShadowSprite");

            InitializeGameObject();
            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObject()
        {
            shadow = new Shadow(texture, new KeyBoardReader());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            shadow.Update(gameTime);
            foreach (Block tile in level.CollisionTiles)
            {
                shadow.Collision(tile.Rectangle, level.Width, level.Height);
            }
            //List clearen
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // TODO: Add sprites
            level.DrawWorld(_spriteBatch);
            shadow.Draw(_spriteBatch);
            

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
