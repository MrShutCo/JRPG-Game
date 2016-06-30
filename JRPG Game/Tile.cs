using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class Tile {

        //TODO: ADD a tilesheet and a room
        Room Room;
        int tileType;
        int X;
        int Y;

        public Tile(Room room, int tiletype, int x, int y) {
            Room = room;
            tileType = tiletype;
            X = x;
            Y = y;
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (tileType != -1)
            spriteBatch.Draw(Room.TileSheets["world"].TextureSheet[tileType], new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize), Color.White);
        }


    }
}
