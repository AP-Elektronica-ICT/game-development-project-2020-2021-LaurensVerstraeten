using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Collision
{
    public enum angle { None, Top, Bottom, Left, Right}
    public class CollisionManager
    {
        public angle CheckCollision(Rectangle collisionbox, Rectangle obstacle)
        {
            if (collisionbox.Intersects(obstacle))
            {
                /*
                if (collisionbox.Right > obstacle.Left && collisionbox.Left < obstacle.Left && ((collisionbox.Top < obstacle.Top && collisionbox.Bottom > obstacle.Bottom) || (collisionbox.Top > obstacle.Top && collisionbox.Top < obstacle.Bottom) || (collisionbox.Bottom > obstacle.Top && collisionbox.Bottom < obstacle.Bottom)))
                {
                    return angle.Right;
                }
                if (collisionbox.Right > obstacle.Right && collisionbox.Left < obstacle.Left && ((collisionbox.Top < obstacle.Top && collisionbox.Bottom > obstacle.Bottom) || (collisionbox.Top > obstacle.Top && collisionbox.Top < obstacle.Bottom) || (collisionbox.Bottom > obstacle.Top && collisionbox.Bottom < obstacle.Bottom)))
                {
                    return angle.Left;
                }
                */
                return angle.Right;
            }
            return angle.None;
        }
    }
}
