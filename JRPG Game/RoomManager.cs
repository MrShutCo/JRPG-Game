using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class RoomManager {

        public Dictionary<string, Room> Rooms;

        public Room CurrentRoom;

        public RoomManager() {
            Rooms = new Dictionary<string, Room>();
        }

        public void AddRoom(string name, Room room) {
            Rooms[name] = room;
        }

        public void SetRoom(string name) {
            CurrentRoom = Rooms[name];
        }

        public void Update(GameTime gameTime) {
            CurrentRoom.Update(gameTime);
        }

    }
}
