﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class Room {

        public int RoomWidth;
        public int RoomHeight;

        public int TilePixelSize;

        public Dictionary<string, TileLayer> TileLayers;

        public Dictionary<string, TileSheet> TileSheets;

        public CollisionLayer CollisionLayer;

        public List<GameObject> GameObjects;

        public Character Character;

        public Room(int width, int height) {
            TileSheets = new Dictionary<string, TileSheet>();
            TileLayers = new Dictionary<string, TileLayer>();
            GameObjects = new List<GameObject>();
            CollisionLayer = new CollisionLayer(this);
            Character = new Character(TexturePool.GetTexture("robot_l"), new Vector2(32,32),this);
            RoomWidth = width;
            RoomHeight = height;
            TilePixelSize = 32;
        }

        public void AddTileSheet(string name, TileSheet tileSheet) {
            TileSheets[name] = tileSheet;
            
        }

        public void AddTileLayer(string name, TileLayer tileLayer) {
            TileLayers[name] = tileLayer;
        }

        public void AddGameObject(GameObject go) {
            GameObjects.Add(go);
        }

        public void AddCollider(Rectangle rect) {
            CollisionLayer.CollisionRectangles.Add(rect);
        }

        //TODO: Maybe add a getter for accessing TileSheets and TileLayers

        public void Draw(SpriteBatch spriteBatch) {
            foreach (KeyValuePair<string, TileLayer> tl in TileLayers) {
                RenderMapLayer(0, 0, tl.Value.LayerContent, RoomWidth, spriteBatch);
            }
            foreach(GameObject go in GameObjects) {
                go.Draw(spriteBatch);
            }
            Character.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime) {
            foreach(GameObject go in GameObjects) {
                go.Update(gameTime);
            }
            Character.Update(gameTime);
        }

        public void RenderMapLayer(int x, int y, int[] map, int mapWidth, SpriteBatch spriteBatch) {
            int tileColumn = 1;
            int tileRow = 1;
            for (int i = 0; i <= map.Length - 1; i++) {
                int pixelPosX = x + (tileColumn - 1) * TilePixelSize;
                int pixelPosY = y + (tileRow - 1) * TilePixelSize;
                //TODO, add TileSheet property to each Tile
                if (map[i] != -1) {
                    spriteBatch.Draw(TileSheets["world"].TextureSheet[map[i]], new Vector2(pixelPosX, pixelPosY), Color.White);
                }

                tileColumn++;
                if (tileColumn > mapWidth) {
                    tileColumn = 1;
                    tileRow++;
                }

            }
        }

    }
}
