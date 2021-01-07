using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Command
{
    public class JumpCommand : IGameCommand
    {
        private Shadow character;
        public void Context(Shadow shadow)
        {
            character = shadow;
        }

        public void Execute()
        {
            character.velocity.Y = character.direction.Y;
            character.hasJumped = true;
        }
    }
}
