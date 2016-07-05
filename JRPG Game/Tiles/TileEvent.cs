using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileEvent : Tile {

        public TileEvent(Room room, int x, int y, TileType tileType)
            :base(room,x,y,tileType){

        }

    }
}
