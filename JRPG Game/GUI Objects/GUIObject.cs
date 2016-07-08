using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GUI_Objects {
    public class GUIObject {

        public Texture2D Texture;
        public Vector2 Position;
        public bool IsShowing;

        public GUIObject() {
        }

        public void StopShowing() {
            IsShowing = false;
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
        }

    }
}
