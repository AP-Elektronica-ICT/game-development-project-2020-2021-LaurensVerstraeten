using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowGame.Animation;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame
{
    public class Shadow : IGameObject
    {
        private Texture2D shadowTexture;
        private Animatie animatie;
        private Vector2 positie;
        private Vector2 snelheid;
        private Vector2 versnelling;
        private Vector2 mouseVector;
     
        public Shadow(Texture2D texture)
        {
            shadowTexture = texture;
            animatie = new Animatie();
            for (int i = 0; i < 1260; i += 126)
            {
                animatie.AddFrame(new AnimationFrame(new Rectangle(i, 0, 126, 111)));
            }

            positie = new Vector2(10, 10);
            snelheid = new Vector2(1, 1); //10 lijkt een goede snelheid voor sprite
            versnelling = new Vector2(0.1f, 0.1f);

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

        public void Update(GameTime gameTime)
        {
            Move(GetMouseState());
            animatie.Update(gameTime);
        }

        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }

        private void Move(Vector2 mouse) 
        {
            var direction = Vector2.Add(mouse, -positie);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 0.5f);

            snelheid += direction;
            snelheid = Limit(snelheid, 5);
            positie += snelheid;

            if (positie.X > 675 || positie.X < 0)
            {
                snelheid.X *= -1;
                versnelling.X *= -1;
            }
            if (positie.Y > 375 || positie.Y < 0 )
            {
                snelheid.Y *= -1;
                versnelling.Y *= -1;
            }
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shadowTexture, positie, animatie.currentFrame.SourceRectangle, Color.White);
        }


    }
}
