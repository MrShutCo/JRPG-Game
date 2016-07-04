using JRPG_Game.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileTeleporter : Tile {

        public Room DestRoom;
        string destName;
        public int DestX;
        public int DestY;

        public TileTeleporter(Room room, string destRoom, int curX, int curY, int destX, int destY, TileType tileType)
            : base(room, curX, curY, tileType) {
            destName = destRoom;
            DestX = destX;
            DestY = destY;
        }

        public void Teleport() {
            RoomManager.SetRoom(destName);
            RoomManager.CurrentRoom.Character.X = DestX;
            RoomManager.CurrentRoom.Character.Y = DestY;
        }

    }
}
