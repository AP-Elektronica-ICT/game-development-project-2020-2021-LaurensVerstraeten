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
        //public List<Rectangle> obstacleList { get; set; } = new List<Rectangle>();
        public Vector2 speed;

        public MoveCommand()
        {
            speed = new Vector2(5, 1);
        }
        
        //public void GiveRectangleObstacle(Rectangle _obstacle)
        //{
        //    obstacleList.Add(_obstacle);
        //}

        //public void DeleteList()
        //{
        //    obstacleList.Clear();
        //}

        //right en bottom in array steken
        public void Execute(ITransform transform, Vector2 direction, Rectangle hitBox)
        {
            //foreach (Rectangle obstacle in obstacleList)
            //{
            //    if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.Right)
            //    {
            //        direction = Vector2.Zero;
            //        //Debug.WriteLine("RECHTS");
            //        //Global.hasJumped = true;
            //    }
            //    if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.Left)
            //    {
            //        direction = Vector2.Zero;
            //        Debug.WriteLine("LINKS");
            //        //Global.hasJumped = true;
            //    }
            //    if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.Top)
            //    {
            //        //speed.Y = 0f;
            //        //Global.hasJumped = false;
            //    }
            //    if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.Bottom)
            //    {
            //        speed.Y = 0f;
            //        //Global.hasJumped = false;
            //        Debug.WriteLine("BOTTOM");
            //    }
            //    //else if (Global.colMan.CheckCollision(hitBox, obstacle) == angle.None)
            //    //{
            //    //    speed.Y = 1f;
            //    //    //Global.hasJumped = true;
            //    //    Debug.WriteLine("NO COL DEC");
            //    //    //direction.Y += 3f;
            //    //}

            //}
            
            direction *= speed;
            transform.Position += direction;            
        }


    }
}
