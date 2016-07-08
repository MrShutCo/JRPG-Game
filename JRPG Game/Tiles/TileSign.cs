using JRPG_Game.GUI_Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileSign : Tile {

        public List<string> ReadableText;
        public TileSign(Room room, List<string> text, int x, int y, TileType tileType)
            :base(room, x, y, tileType){
            ReadableText = text;
        }

        public void LookAt() {
            //TODO: Change reading of text to either multiple textboxes, or XML reading
            List<DialogueBox> dia = new List<DialogueBox>();
            foreach(string s in ReadableText) {
                dia.Add(new DialogueBox(s));
            }
            Conversation conv = new Conversation(dia);
            GUIManager.currentConversation = conv;
        }

    }
}
