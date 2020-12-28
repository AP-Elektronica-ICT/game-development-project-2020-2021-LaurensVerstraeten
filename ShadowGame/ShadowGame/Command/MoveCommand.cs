using Microsoft.Xna.Framework;
using ShadowGame.Collision;
using ShadowGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ShadowGame.Command
{
    class MoveCommand : IGameCommand
    {
        private CollisionManager colMan;
        public Rectangle colBox;
        public Rectangle obstacle;
        public Vector2 speed;

        public MoveCommand()
        {
            colMan = new CollisionManager();
            this.speed = new Vector2(5, 0);
        }

        public void GiveRectangleColBox(Rectangle _colbox)
        {
            colBox = _colbox;
        }
        public void GiveRectangleObstacle(Rectangle _obstacle)
        {
            obstacle = _obstacle;
        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            if (colMan.CheckCollision(colBox, obstacle) == angle.Right)
            {
                speed = Vector2.Zero;
                Debug.WriteLine("aaaaaa");
            }
            direction *= speed;
            transform.Position += direction;            
        }


    }
}
