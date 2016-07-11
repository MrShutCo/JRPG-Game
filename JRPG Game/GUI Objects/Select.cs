using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GUI_Objects {
    public class Select {

        public Texture2D Texture;
        public Vector2 Position;
        public string Name;

        public event Action OnSelectEvent;

        public Select(Vector2 position, string name, Action OnSelect) {
            Texture = TexturePool.GetTexture("select");
            Position = position;
            Name = name;
            OnSelectEvent = OnSelect;
        }

        public void Choose() {
            OnSelectEvent();
        }


        internal void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, Color.White);
            
        }

    }
}
