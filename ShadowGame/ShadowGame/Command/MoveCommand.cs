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
        public Rectangle colBox {get; set; }
        public List<Rectangle> obstacleList { get; set; } = new List<Rectangle>();
        public Vector2 speed;

        public MoveCommand()
        {
            speed = new Vector2(5, 0);
        }

        public  void GiveRectangleColBox(Rectangle _colbox)
        {
            colBox = _colbox;
        }
        public  void GiveRectangleObstacle(Rectangle _obstacle)
        {
            obstacleList.Add(_obstacle);

        }
        public void Execute(ITransform transform, Vector2 direction)
        {
            foreach (Rectangle obstacle in obstacleList)
            {
                if (Global.colMan.CheckCollision(colBox, obstacle) == angle.Right)
                {
                    speed = Vector2.Zero;
                    Debug.WriteLine("aaaaaa");
                }
            }
            
            direction *= speed;
            transform.Position += direction;            
        }


    }
}
