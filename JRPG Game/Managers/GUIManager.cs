using JRPG_Game.GUI_Objects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public static class GUIManager {

        public static Dictionary<string, GUIObject> GUIObjects = new Dictionary<string, GUIObject>();

        public static Conversation currentConversation;

        public static void Draw(SpriteBatch spriteBatch) {
            if (GUIObjects != null) {
                foreach (KeyValuePair<string, GUIObject> gui in GUIObjects) {
                    gui.Value.Draw(spriteBatch);
                }
            }
            if (currentConversation != null) {
                currentConversation.Draw(spriteBatch);
            }
        }

    }
}
