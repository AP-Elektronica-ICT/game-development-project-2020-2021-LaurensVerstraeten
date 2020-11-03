using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Interfaces
{
    interface IGameObject
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
