using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JRPG_Game.GUI_Objects;
using Microsoft.Xna.Framework.Input;

namespace JRPG_Game.GameStates {
    class MenuState : IState {

        public StateStack stateStack { get; set; }

        public InputHandler menuHandler;

        public SelectBox MenuOptions;

        public void OnEnter() {
            List<Select> selects = new List<Select>() { new Select(new Vector2(500, 50), "Items", new Action(itemMenu)),
            new Select(new Vector2(500, 125), "Equipment", new Action(equipMenu)), new Select(new Vector2(500, 200), "Stats", new Action(statsMenu)),
            new Select(new Vector2(500, 275), "Options", new Action(configMenu)), new Select(new Vector2(500, 350), "Exit", new Action(exitMenu))};
            MenuOptions = new SelectBox(selects);
            menuHandler = new InputHandler();
            menuHandler.RegisterKey(Keys.Up, MenuOptions.PrevOption);
            menuHandler.RegisterKey(Keys.Down, MenuOptions.NextOption);
            menuHandler.RegisterKey(Keys.Enter, MenuOptions.Confirm);
        }

        void itemMenu() {
            stateStack.Push("itemmenu");
        }

        void equipMenu() {
            
        }

        void statsMenu() {

        }

        void configMenu() {

        }

        void exitMenu() {
            stateStack.Pop();
        }

        public void OnExit() {
            
        }

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            MenuOptions.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime) {
            menuHandler.Update(gameTime);
        }
    }
}
