using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Menu
{
    class VictoryState : States
    {
        private List<Component> _components;
        public VictoryState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var menuTexutre = _content.Load<Texture2D>("Button");
            var menuFont = _content.Load<SpriteFont>("Font");
            var quitTexture = _content.Load<Texture2D>("Button");
            var quitFont = _content.Load<SpriteFont>("Font");

            var menuButton = new Button(menuTexutre, menuFont)
            {
                Position = new Vector2((Global.screenWidth / 2) - (177 / 2), 400),
                Text = "MENU",
            };

            menuButton.Click += menuButton_Click;

            var quitButton = new Button(quitTexture, quitFont)
            {
                Position = new Vector2((Global.screenWidth / 2) - (177 / 2), 550),
                Text = "QUIT",
            };

            quitButton.Click += quitButton_Click;

            _components = new List<Component>()
            {
                menuButton,
                quitButton,
            };

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Global.spriteBatch.Begin();
            Global.spriteBatch.Draw(_content.Load<Texture2D>("victoryScreen"), new Rectangle(0, 0, Global.screenWidth, Global.screenHeight), Color.White);
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
