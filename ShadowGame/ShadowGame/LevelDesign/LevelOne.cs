using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.LevelDesign
{
    class LevelOne
    {
        public Texture2D texture;

        public byte[,] levelArray = new byte[,]
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {1,0,1,0,1,0},
            {0,1,0,1,0,1},
        };

        //private Block[,] blockArray = new Block[4, 6];

    }
}
