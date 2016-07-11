using JRPG_Game.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Managers {
    public static class StatManager {

        public static Stat Stats;
        public static CharInventory Inventory = new CharInventory();

        //public static Item getItem(string name) {
        //    return Inventory.Single(item => item.Name == name);
        //}

        #region Tests

        public static void FillInventory(int size) {
            Inventory.AddItem(new Item(TexturePool.GetTexture("testItem"), "test"), size);
        }


        #endregion

        //TODO: Make sure this actually works
        public static ItemStack[,] getItemGrid(int width, int height) {
            ItemStack[,] itemGrid = new ItemStack[width, height];
            int x = 0;
            int y = 0;
            foreach(ItemStack i in Inventory.Items) {
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
