using Microsoft.Xna.Framework;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Command
{
    interface IGameCommand
    {
        //enemy en hero moeten dan overerven van entity
        void Context(Shadow entity);
        void Execute();

        //void GiveRectangleObstacle(Rectangle _obstacle);
    }
}
