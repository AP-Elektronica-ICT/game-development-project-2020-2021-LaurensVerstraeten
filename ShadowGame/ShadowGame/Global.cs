using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.Collision;
using ShadowGame.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame
{
    public static class Global
    {
        public static MoveCommand moveCommand = new MoveCommand();

        public static JumpCommand jumpCommand = new JumpCommand();

        //public static CollisionManager colMan = new CollisionManager();
        public static int shadowScale = 42;
        public static ContentManager Content;
        public static float shadowSpeed = 3.5f;
        public static bool reset = false;
        public static bool gameOver = false;
        public static SpriteBatch spriteBatch;
        public static GraphicsDeviceManager graphicsManager;
        public static int screenWidth = 1280;
        public static int screenHeight = 720;
        public static int currentLevel = 0;
        //public static bool hasJumped { get; set; }
    }
}
