using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    class Tile {

        //TODO: ADD a tilesheet and a room
        Room Room;
        Texture2D Texture;
        int X;
        int Y;

        public Tile(Room room, Texture2D texture) {
            Room = room;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize), Color.White);
        }


    }
}
