using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JRPG_Game.Menus;
using JRPG_Game.GUI_Objects;
using Microsoft.Xna.Framework.Input;

namespace JRPG_Game.GameStates {
    class MainMenuState : IState {

        public StateStack stateStack { get; set; }

        SelectBox mainSelect;
        InputHandler MenuInput;

        public void OnEnter() {
            //TODO, Select should have an Action in initializer
            MenuInput = new InputHandler();
            List<Select> select = new List<Select>();
            var main = new Select(new Vector2(325, 125), "Start Game", new Action(GotoMainRoom));
            var load = new Select(new Vector2(325, 200), "Load Game", new Action(Load));
            var exit = new Select(new Vector2(325, 275), "Exit Game", new Action(Exit));
            select.Add(main);
            select.Add(load);
            select.Add(exit);
            mainSelect = new SelectBox(select);
            MenuInput.RegisterKey(Keys.Up, mainSelect.PrevOption);
            MenuInput.RegisterKey(Keys.Down, mainSelect.NextOption);
            MenuInput.RegisterKey(Keys.Enter, mainSelect.Confirm);
        }

        private void GotoMainRoom() {
            stateStack.Pop();
        }

        private void Load() {
            //TODO: Add loading, and maybe a way to select what you want to load
        }

        private void Exit() {
            //TODO: Just straight up exit
        }

        public void OnExit() {
            
        }

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            //spriteBatch.Draw(TexturePool.GetTexture("menuscreen"), new Vector2(0,0), Color.White);
            mainSelect.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime) {
            MenuInput.Update(gameTime);
        }
    }
}
