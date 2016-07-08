using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GUI_Objects {
    public class Conversation: GUIObject {

        public List<DialogueBox> Text;
        public DialogueBox currentText;
        public int convNo;

        public Conversation(List<DialogueBox> dia) {
            Text = dia;
            convNo = 0;
            currentText = dia[0];
        }

        public override void Draw(SpriteBatch spriteBatch) {
            currentText.Draw(spriteBatch);
        }

        public void NextTextBox() {
            convNo++;

            currentText = Text[convNo];
        }
    }
}
