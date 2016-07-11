using JRPG_Game.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Managers {
    public static class StatManager {

        public static Stat Stats;
        public static List<Item> Inventory = new List<Item>();

        public static Item getItem(string name) {
            return Inventory.Single(item => item.Name == name);
        }

        #region Tests

        public static void FillInventory(int size) {
            for (int x = 0; x < size; x++)
                Inventory.Add(new Item(TexturePool.GetTexture("testItem"), "test"));
        }

        #endregion

        //TODO: Make sure this actually works
        public static Item[,] getItemGrid(int width, int height) {
            Item[,] itemGrid = new Item[width, height];
            int x = 0;
            int y = 0;
            foreach(Item i in Inventory) {
                if (x >= width) {
                    x = 0;
                    y++;
                }
                itemGrid[x, y] = i;
                x++;
                
            }
            return itemGrid;
        }

        //TODO: Add item system and things like quests and equipment


    }
}
