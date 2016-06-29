using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class CollisionLayer {

        public List<Rectangle> CollisionRectangles;
        public Room Room;

        public CollisionLayer(Room room) {
            Room = room;
            CollisionRectangles = new List<Rectangle>();
        }

        

    }
}
