using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ShadowGame.Input
{
    class KeyBoardReader : IInputReader
    {        
        public Vector2 ReadInput(bool hasJumped)
        {            
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
            }
            if (state.IsKeyDown(Keys.Up) && hasJumped == false)
            {
                direction = new Vector2(0, -7.8f);
                hasJumped = true;                
            }

            return direction;
        }
    }
}
