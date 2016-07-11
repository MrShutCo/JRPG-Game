using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JRPG_Game.Inventory;
using JRPG_Game.Managers;
using Microsoft.Xna.Framework.Input;
using JRPG_Game.GUI_Objects;

namespace JRPG_Game.GameStates.Menu {
    public class ItemMenuState : IState {

        public StateStack stateStack { get; set; }
        Item[,] itemGrid;

        SelectBox itemOptions;

        InputHandler itemMenu;

        public void OnEnter() {
            //Creates temp items for storing
            StatManager.FillInventory(56);
            //Make a grid 10x10 to fill
            itemGrid = StatManager.getItemGrid(10, 10);
            itemMenu = new InputHandler();
            List<Select> itemSelector = new List<Select> { new Select(new Vector2(450, 250), "Select", Select), new Select(new Vector2(450, 325), "Exit", ExitMenu) };
            itemOptions = new SelectBox(itemSelector);
            itemMenu.RegisterKey(Keys.Up, itemOptions.PrevOption);
            itemMenu.RegisterKey(Keys.Down, itemOptions.NextOption);
            itemMenu.RegisterKey(Keys.Enter, itemOptions.Confirm);
        }

        void ExitMenu() {
            stateStack.Pop();
        }

        void Select() {

        }

        public void OnExit() {
            
        }

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            itemOptions.Draw(spriteBatch);
            for (int x = 0; x < itemGrid.GetLength(0); x++) {
                for (int y = 0; y < itemGrid.GetLength(1); y++) {
                    spriteBatch.Draw(TexturePool.GetTexture("itemSlot"), new Vector2(x * 34 + 64, y * 34 + 64), Color.White);
                    if (itemGrid[x,y] != null)
                    spriteBatch.Draw(itemGrid[x, y].itemImage, new Vector2(x * 34 + 64, y * 34 + 64), Color.White);
                    
                 }
            }
            spriteBatch.End();
        }

        public void Update(GameTime gameTime) {
            itemMenu.Update(gameTime);
        }
    }
}
