using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileLayer {

        public Room Room;
        public List<Tile> Tiles;

        public TileLayer(Room room, List<Tile> tiles) {
            Room = room;
            Tiles = tiles;
        }

    }
}
