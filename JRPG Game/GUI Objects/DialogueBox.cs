using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JRPG_Game.GUI_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class DialogueBox : GUIObject {

        public string Text;

        public DialogueBox(Texture2D texture, Vector2 position, bool isShowing, string text)
            : base(texture,position,isShowing) { 
            Text = text;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), Text, new Vector2(20, 20), Color.Black);
        }

    }
}
