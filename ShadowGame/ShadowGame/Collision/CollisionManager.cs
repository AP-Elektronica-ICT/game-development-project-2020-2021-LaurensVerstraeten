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
                    angle = angle.Right;

                    if (collisionbox.Top < obstacle.Top && collisionbox.Bottom > obstacle.Bottom)
                    {
                        angle = angle.Right;

                        if (collisionbox.Top > obstacle.Top && collisionbox.Top < obstacle.Bottom)
                        {
                            angle = angle.Right;

                            if (collisionbox.Bottom > obstacle.Top && collisionbox.Bottom < obstacle.Bottom)
                            {
                                angle = angle.Right;
                            }
                        }
                    }
                }

                if (collisionbox.Right > obstacle.Right && collisionbox.Left < obstacle.Left)
                {
                    angle = angle.Left;

                    if (collisionbox.Top < obstacle.Top && collisionbox.Bottom > obstacle.Bottom)
                    {
                        angle = angle.Left;

                        if (collisionbox.Top > obstacle.Top && collisionbox.Top < obstacle.Bottom)
                        {
                            angle = angle.Left;

                            if (collisionbox.Bottom > obstacle.Top && collisionbox.Bottom < obstacle.Bottom)
                            {
                                angle = angle.Left;
                            }
                        }
                    }
                }

                return angle;
            }
            else { return angle.None; }
        }
    }
}
