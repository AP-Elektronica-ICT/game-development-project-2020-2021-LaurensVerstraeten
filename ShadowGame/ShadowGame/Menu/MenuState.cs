using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using ShadowGame.State;
using System.Text;

namespace ShadowGame.Menu
{
    public class MenuState : States
    {
        private List<Component> _components;             

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var playButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Global.screenWidth/2) - (177/2), 200),
                Text = "PLAY",

            };

            playButton.Click += playButton_Click;

            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Global.screenWidth/2) - (177/2), 350),
                Text = "QUIT",
            };

            quitButton.Click += quitButton_Click;

            _components = new List<Component>()
            {
                playButton,
                quitButton,
            };
        }               

        private void playButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GamePlay(_game, _graphicsDevice,_content));
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Global.spriteBatch.Begin();
            Global.spriteBatch.Draw(_content.Load<Texture2D>("greenhill"), new Rectangle(0, 0, Global.screenWidth, Global.screenHeight), Color.White);
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
