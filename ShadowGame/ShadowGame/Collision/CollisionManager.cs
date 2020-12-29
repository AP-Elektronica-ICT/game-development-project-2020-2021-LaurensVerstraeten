using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Collision
{
    public enum angle { None, Top, Bottom, Left, Right}
    public class CollisionManager
    {
        private angle angle;
        public angle CheckCollision(Rectangle collisionbox, Rectangle obstacle)
        {
            if (collisionbox.Intersects(obstacle))
            {   
                if (collisionbox.Right > obstacle.Left && collisionbox.Left < obstacle.Left)
                {
                    //angle = angle.Right;

                    if (collisionbox.Top - 1 < obstacle.Top && collisionbox.Bottom + 1 > obstacle.Bottom)
                    {
                        angle = angle.Right;                        
                    }
                    if (collisionbox.Top - 1 > obstacle.Top && collisionbox.Top - 1 < obstacle.Bottom)
                    {
                        angle = angle.Right;
                    }
                    if (collisionbox.Bottom + 1 > obstacle.Top && collisionbox.Bottom + 1 < obstacle.Bottom)
                    {
                        angle = angle.Right;
                    }
                }
                
                if (collisionbox.Right > obstacle.Right && collisionbox.Left < obstacle.Right)
                {
                    //angle = angle.Left;
                    
                    if (collisionbox.Top - 1 < obstacle.Top && collisionbox.Bottom + 1 > obstacle.Bottom)
                    {
                        angle = angle.Left;                        
                    }
                    if (collisionbox.Top -1 > obstacle.Top && collisionbox.Top - 1 < obstacle.Bottom)
                    {
                        angle = angle.Left;                        
                    }
                    if (collisionbox.Bottom + 1 > obstacle.Top && collisionbox.Bottom + 1 < obstacle.Bottom)
                    {
                        angle = angle.Left;
                    }
                }

                if (true)
                {
                    if (true)
                    {

                    }
                    if (true)
                    {

                    }
                    if (true)
                    {

                    }
                }
                                            
                return angle;
            }
            else { return angle.None; }
        }
    }
}
