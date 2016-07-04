using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class DialogueBox {

        public Texture2D Background;
        public string Text;

        public DialogueBox(string text) {
            Background = TexturePool.GetTexture("dialogue");
            Text = text;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Background, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), Text, new Vector2(20, 20), Color.Black);
        }

    }
}
