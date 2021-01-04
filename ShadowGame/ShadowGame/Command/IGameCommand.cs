using Microsoft.Xna.Framework;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Command
{
    interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction, Rectangle hitBox);

        //void GiveRectangleObstacle(Rectangle _obstacle);
    }
}
