using Microsoft.Xna.Framework;
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

        public List<GameObject> GameObjects;

        public Character Character;

        public string Name;

        public Room(string name, int width, int height) {
            TileSheets = new Dictionary<string, TileSheet>();
            TileLayers = new Dictionary<string, TileLayer>();
            GameObjects = new List<GameObject>();
            Character = new Character(TexturePool.GetTexture("robot_l"),this, 1,1);
            RoomWidth = width;
            RoomHeight = height;
            TilePixelSize = 32;
            Name = name;
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

        //TODO: Maybe add a getter for accessing TileSheets and TileLayers

        public void Draw(SpriteBatch spriteBatch) {
            foreach (KeyValuePair<string, TileLayer> tl in TileLayers) {
                foreach (TileVisible t in tl.Value.TileLayout.OfType<TileVisible>()) {
                    t.Draw(spriteBatch);
                }
            }
            Character.Draw(spriteBatch);
            foreach (GameObject go in GameObjects) {
                go.Draw(spriteBatch);
            }
            
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
