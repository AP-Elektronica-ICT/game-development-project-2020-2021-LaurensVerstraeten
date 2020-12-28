using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Collision
{
    class CollisionManager
    {
        public bool CheckCollision(Rectangle collisionbox, Rectangle obstacle)
        {
            if (collisionbox.Intersects(obstacle))
            {
                if (collisionbox.Right > obstacle.Left && collisionbox.Left < obstacle.Left && ((collisionbox.Top < obstacle.Top && collisionbox.Bottom > obstacle.Bottom) || (collisionbox.Top > obstacle.Top && collisionbox.Top < obstacle.Bottom) || (collisionbox.Bottom > obstacle.Top && collisionbox.Bottom < obstacle.Bottom)))
                {
                    //rechter kant botst
                }
                if (collisionbox.Right > obstacle.Right && collisionbox.Left < obstacle.Left && ((collisionbox.Top < obstacle.Top && collisionbox.Bottom > obstacle.Bottom) || (collisionbox.Top > obstacle.Top && collisionbox.Top < obstacle.Bottom) || (collisionbox.Bottom > obstacle.Top && collisionbox.Bottom < obstacle.Bottom)))
                {
                    //linker kant botst
                }
                return true;
            }
            return false;
        }
    }
}
