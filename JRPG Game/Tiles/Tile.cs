using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {

    public enum TileType {
        ground,
        collider,
        teleporter,
        readable,
        other
    }

    public class Tile {

        //TODO: ADD a tilesheet and a room
        
        protected Room Room;
        protected int X;
        protected int Y;
        public TileType TileType;

        public Tile(Room room, int x, int y, TileType tile_type) {
            Room = room;
            X = x;
            Y = y;
            TileType = tile_type;
        }
    }
}
