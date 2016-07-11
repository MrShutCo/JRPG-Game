using JRPG_Game.GameStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public static class RoomManager {

        static List<Room> Rooms = new List<Room>();

        public static Room CurrentRoom;

        public static void AddRoom(Room room) {
            Rooms.Add(room);
        }

        public static void ClearRoom() {
            CurrentRoom = null;
        }

        public static void SetRoom(string room) {
            CurrentRoom = Rooms.Single(s => s.Name == room);
        }

        public static Room GetRoom(string room) {
            return Rooms.Single(s => s.Name == room);
        }

        public static void Update(GameTime gameTime) {
            CurrentRoom.Update(gameTime);
        }

    }
}
