using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileLayer {

        public Room Room;
        public Tile[,] TileLayout;

        public TileLayer(Room room, Tile[,] tiles) {
            Room = room;
            TileLayout = tiles;
        }

        public Tile GetTileAt(int x, int y) {
            return TileLayout[x, y];
        }

    }
}
