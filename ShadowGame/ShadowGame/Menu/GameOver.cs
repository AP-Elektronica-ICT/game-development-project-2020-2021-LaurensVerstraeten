using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Menu
{
    class GameOver : States
    {
        private List<Component> _components;
        public GameOver(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var gameOverTexture = _content.Load<Texture2D>("Button");            
            var menuTexture = _content.Load<Texture2D>("Button");
            var menuFont = _content.Load<SpriteFont>("Font");

            var menuButton = new Button(menuTexture, menuFont)
            {
                Position = new Vector2((Global.screenWidth / 2) - (177 / 2), 500),
                Text = "MENU",
            };

            menuButton.Click += menuButton_Click;

            _components = new List<Component>()
            {
                menuButton,
            };
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Global.spriteBatch.Begin();
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            Global.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
