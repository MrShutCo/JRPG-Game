using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JRPG_Game.Menus;

namespace JRPG_Game.GameStates {
    class MainMenuState : IState {

        Button startGame;

        public StateStack stateStack { get; set; }

        public void OnEnter() {
            startGame = new Button(new Rectangle(100, 100, 200, 132));
            startGame.OnClickEvent += new Action(GotoMainRoom);
        }

        private void GotoMainRoom() {
            stateStack.Pop();
        }

        public void OnExit() {
            
        }

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            spriteBatch.Draw(TexturePool.GetTexture("menuscreen"), new Vector2(0,0), Color.White);
            startGame.Draw(spriteBatch, TexturePool.GetTexture("button"));
            spriteBatch.End();
        }

        public void Update(GameTime gameTime) {
            startGame.Update();
        }
    }
}
