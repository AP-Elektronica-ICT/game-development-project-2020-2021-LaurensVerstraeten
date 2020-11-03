using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.Animation;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame
{
    public class Shadow : IGameObject
    {
        Texture2D shadowTexture;
        Animatie animatie;
     
        public Shadow(Texture2D texture)
        {
            shadowTexture = texture;
            animatie = new Animatie();
            for (int i = 0; i < 1260; i += 126)
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(i, 0, 126, 111)));
            }
            /*
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(126, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(252, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(378, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(504, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(630, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(756, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(882, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(1.008, 0, 126, 111)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(1.134, 0, 126, 111)));
            */
        }

        public void Update()
        {
            animatie.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shadowTexture, new Vector2(10, 10), animatie.currentFrame.SourceRectangle, Color.White);
        }


    }
}
