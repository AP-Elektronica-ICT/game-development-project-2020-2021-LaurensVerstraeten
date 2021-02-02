using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.World;
using ShadowGame.Command;
using System;
using System.Collections.Generic;
using System.Text;
using ShadowGame.Menu;
using ShadowGame.Collision;
using System.Diagnostics;

namespace ShadowGame.LevelDesign
{
    class Level
    {
        //platform classe maken, rectangle maken (verschillende platformen) met eigen draw functie
        //platformen zijn een array van tiles
        //in level heb je een list/array van uw platforms en hier roep je uw array aan om te draw
        //array roept rectangles aan
        public ContentManager _content;
        private List<Block> collisionTiles = new List<Block>();
        private List<Coin> collisionCoins = new List<Coin>();
        public List<Block> CollisionTiles
        {
            get { return collisionTiles; }
        }

        public List<Coin> CollisionCoins
        {
            get { return collisionCoins; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
       
        private byte[,] _map;
        public Level(byte [,] map, ContentManager content)
        {
            _map = map;            
            _content = content;
        }

        public bool isCleared = false;
        private int coinsCollected;

        public void CreateWorld(int size)
        {
            for (int x = 0; x < _map.GetLength(1); x++)
            {
                for (int y = 0; y < _map.GetLength(0); y++)
                {
                    int number = _map[y, x];
                    if (number == 1)
                    {
                        collisionTiles.Add(new Block(new Rectangle(x * size, y * size, size, size), _content));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                    }
                    if (number == 2)
                    {
                        collisionCoins.Add(new Coin(new Rectangle(x * size, y * size, size, size), _content));
                    }
                }

            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            foreach (Block tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
            foreach (Coin coin in collisionCoins)
            {
                coin.Draw(spriteBatch);
            }
        }

        public void Update(Shadow shadow)
        {
            foreach (Block tile in CollisionTiles)
            {
                shadow.Collision(tile.Rectangle, Width, Height);
            }
           
            for (int i = 0; i < CollisionCoins.Count; i++)
            {
                if (CollisionManager.TouchCoin(shadow.hitBox, CollisionCoins[i].Rectangle))
                {
                    CollisionCoins[i].isCollected = true;
                    CollisionCoins[i].Update();
                    coinsCollected++;

                    if (coinsCollected == CollisionCoins.Count)
                    {
                        Global.currentLevel++;
                        Global.reset = true;                      
                    }
                }
            }
        }

    }
}
