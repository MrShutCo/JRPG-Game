using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class DialogueBox : GameObject {

        public string Text;

        public DialogueBox(Texture2D texture, Room room, int x, int y, string text)
            : base(texture,room,x,y) { 
            Text = text;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), Text, new Vector2(20, 20), Color.Black);
        }

    }
}
