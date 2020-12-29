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
        public List<Rectangle> obstacleList { get; set; } = new List<Rectangle>();
        public Vector2 speed;

        public MoveCommand()
        {
            speed = new Vector2(5, 0);
        }
        
        public void GiveRectangleObstacle(Rectangle _obstacle)
        {
            obstacleList.Add(_obstacle);

        }
        public void Execute(ITransform transform, Vector2 direction, Rectangle hitBox)
        {
            foreach (Rectangle obstacle in obstacleList)
            {
                if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.Right)
                {
                    direction = Vector2.Zero;
                    Debug.WriteLine("aaaaaa");
                }
                if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.Left)
                {
                    speed = Vector2.Zero;

                }

            }
            
            direction *= speed;
            transform.Position += direction;            
        }


    }
}
