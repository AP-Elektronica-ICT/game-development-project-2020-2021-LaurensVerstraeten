using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ShadowGame.Animation
{
    public class Animatie
    {
        public AnimationFrame currentFrame { get; set; }

        private List<AnimationFrame> frames;

        private int counter;

        private double frameMovement = 0;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            currentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            currentFrame = frames[counter];

            frameMovement += currentFrame.SourceRectangle.Width* gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= currentFrame.SourceRectangle.Width/10)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

    }
}
