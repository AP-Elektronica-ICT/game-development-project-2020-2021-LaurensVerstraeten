using Microsoft.Xna.Framework;
using ShadowGame.Collision;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ShadowGame.Command
{
    public class MoveCommand : IGameCommand
    {        
        private Shadow character;
        public void Context(Shadow shadow)
        {
            character = shadow;
        }
       
        public void Execute()
        {
            
            character.velocity.X = Global.shadowSpeed * character.direction.X;
        }
    }
}
