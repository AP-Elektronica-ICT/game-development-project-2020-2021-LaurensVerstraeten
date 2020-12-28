using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.World;
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

        private Block[,] blockArray = new Block[4, 6];

        private ContentManager Content;

        public LevelOne(ContentManager content)
        {
            this.Content = content;
            InitializeContent();
        }

        private void InitializeContent()
        {
            texture = Content.Load<Texture2D>("block");
        }

        public void CreateWorld()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (levelArray[x, y] == 1)
                    {
                        blockArray[x, y] = new Block(texture, new Vector2(x + 30 , y + 30));
                    }
                }

            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }

    }
}
