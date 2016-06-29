using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileLayer {

        public Room Room;
        public int[] LayerContent;

        public TileLayer(Room room, int[] layerContent) {
            Room = room;
            LayerContent = layerContent;
        }

    }
}
