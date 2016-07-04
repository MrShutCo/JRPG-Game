using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileVisible : Tile {

        public int tileType;

        public TileVisible(Room room, int tile_type, int x, int y, TileType TileType)
            :base(room, x, y, TileType) {
            tileType = tile_type;
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (tileType != -1)
                spriteBatch.Draw(TexturePool.GetTileSheet("testsheet").TextureSheet[tileType], new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize), Color.White);
        }

    }
}
