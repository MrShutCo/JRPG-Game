using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GUI_Objects {
    public class SelectBox : GUIObject {

        public List<Select> Options;
        public Select currSelect;
        public int tracker;

        public SelectBox(List<Select> select) {
            Options = select;
            tracker = 0;
            currSelect = Options[tracker];
        }

        public void Confirm() {
            currSelect.Choose();
        }

        public void NextOption() {
            tracker++;
            if (tracker > Options.Count - 1) {
                tracker = 0;
            }
            currSelect = Options[tracker];
        }

        public void PrevOption() {
            tracker--;
            if (tracker < 0) {
                tracker = Options.Count - 1;
            }
            currSelect = Options[tracker];
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (Select s in Options) {
                if (s != currSelect)
                s.Draw(spriteBatch);
                else {
                    spriteBatch.Draw(currSelect.Texture, currSelect.Position, Color.Red);
                }
                
                spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), s.Name, s.Position + new Vector2(30, 7), Color.Black);
            }
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), currSelect.Name, new Vector2(0, 0), Color.Black);
        }

    }
}
