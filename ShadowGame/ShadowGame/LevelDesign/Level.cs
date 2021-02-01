using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShadowGame.World;
using ShadowGame.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.LevelDesign
{
    class Level
    {
        //platform classe maken, rectangle maken (verschillende platformen) met eigen draw functie
        //platformen zijn een array van tiles
        //in level heb je een list/array van uw platforms en hier roep je uw array aan om te draw
        //array roept rectangles aan
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
        public Level(byte [,] map)
        {
            _map = map;
        }

        public bool isCleared = false;
               

        public void CreateWorld(int size)
        {
            for (int x = 0; x < _map.GetLength(1); x++)
            {
                for (int y = 0; y < _map.GetLength(0); y++)
                {
                    int number = _map[y, x];
                    if (number == 1)
                    {
                        collisionTiles.Add(new Block(new Rectangle(x * size, y * size, size, size)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                    }
                    if (number == 2)
                    {
                        collisionCoins.Add(new Coin(new Rectangle(x * size, y * size, size, size)));
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

    }
}
