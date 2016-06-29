using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Menus {
    public class Button {

        public Rectangle boundingBox;
        public event Action OnClickEvent;


        public Button(Rectangle boundingbox) {
            boundingBox = boundingbox;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture) {
            spriteBatch.Draw(texture, boundingBox, Color.White);
        }

        public void Update() {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (boundingBox.Contains(mousePosition)) {
                if (mouseState.LeftButton == ButtonState.Pressed) {
                    OnClickEvent();
                }
            }
        }
    }
}
