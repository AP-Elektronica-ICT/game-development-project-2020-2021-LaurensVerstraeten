using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Collision
{
    //public enum angle { None, Top, Bottom, Left, Right }
    public class CollisionManager
    {
        public static bool TouchTopOF(this Rectangle hitBox, Rectangle obstacle)
        {

        }
        //    private angle angle;
        //    private int offset = 1;
        //    public angle CheckCollision(Rectangle collisionbox, Rectangle obstacle)
        //    {
        //        if (collisionbox.Intersects(obstacle))
        //        {   
        //            if (collisionbox.Right > obstacle.Left && collisionbox.Left < obstacle.Left && collisionbox.Right + 25 > obstacle.Right)
        //            {
        //                //angle = angle.Right;

        //                if (collisionbox.Top - 1 < obstacle.Top && collisionbox.Bottom + 1 > obstacle.Bottom)
        //                {
        //                    angle = angle.Right;                        
        //                }
        //                if (collisionbox.Top - 1 > obstacle.Top && collisionbox.Top - 1 < obstacle.Bottom)
        //                {
        //                    angle = angle.Right;
        //                }
        //                if (collisionbox.Bottom + 1 > obstacle.Top && collisionbox.Bottom + 1 < obstacle.Bottom)
        //                {
        //                    angle = angle.Right;
        //                }
        //            }

        //            if (collisionbox.Left < obstacle.Right && collisionbox.Right > obstacle.Right && collisionbox.Left - 25 < obstacle.Left)
        //            {
        //                //angle = angle.Left;

        //                if (collisionbox.Top - 1 < obstacle.Top && collisionbox.Bottom + 1 > obstacle.Bottom)
        //                {
        //                    angle = angle.Left;                        
        //                }
        //                if (collisionbox.Top -1 > obstacle.Top && collisionbox.Top - 1 < obstacle.Bottom)
        //                {
        //                    angle = angle.Left;                        
        //                }
        //                if (collisionbox.Bottom + 1 > obstacle.Top && collisionbox.Bottom + 1 < obstacle.Bottom)
        //                {
        //                    angle = angle.Left;
        //                }
        //            }

        //            if (collisionbox.Top - 1 < obstacle.Bottom && collisionbox.Bottom + 1 > obstacle.Bottom && collisionbox.Top - 1 > obstacle.Top)
        //            {
        //                if (collisionbox.Left < obstacle.Left && collisionbox.Right - 1 > obstacle.Left)
        //                {
        //                    angle = angle.Top;
        //                }
        //                if (collisionbox.Left + 1 < obstacle.Right && collisionbox.Right > obstacle.Right)
        //                {
        //                    angle = angle.Top;
        //                }
        //                if (collisionbox.Left > obstacle.Left && collisionbox.Right < obstacle.Right)
        //                {
        //                    angle = angle.Top;
        //                }
        //            }

        //            if (collisionbox.Bottom + 1 > obstacle.Top && collisionbox.Top - 1 < obstacle.Top && collisionbox.Bottom + 1 < obstacle.Bottom)
        //            {
        //                if (collisionbox.Left < obstacle.Left && collisionbox.Right - 1 > obstacle.Left)
        //                {
        //                    angle = angle.Bottom;
        //                }
        //                if (collisionbox.Left + 1 < obstacle.Right && collisionbox.Right > obstacle.Right)
        //                {
        //                    angle = angle.Bottom;
        //                }
        //                if (collisionbox.Left > obstacle.Left && collisionbox.Right < obstacle.Right)
        //                {
        //                    angle = angle.Bottom;
        //                }
        //            }  

        //            return angle;
        //        }
        //        else { return angle.None; }
        //    }
        //}
    }
}
