using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileSign : Tile {

        public string ReadableText;

        public TileSign(Room room, string text, int x, int y, TileType tileType)
            :base(room, x, y, tileType){
            ReadableText = text;
        }

        public void LookAt() {
            DialogueBox diaBox = new DialogueBox(ReadableText);
        }

    }
}
