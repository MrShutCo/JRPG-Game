using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Inventory {
    public class ItemStack {

        public Item Item;
        public int StackSize;

        private readonly int maxStack = 100;

        public ItemStack(Item item, int stackSize = 1) {
            Item = item;
            StackSize = stackSize;
        }

        public void AddItem(int size) {
            if (StackSize >= maxStack) {
                //TODO: Add some sort of thing telling it that its full, or create a new stack
                return;
            }
            if (StackSize + size > maxStack) {
                StackSize = 100;
                //TODO: Add overflow of items to next stack
                return;
            }
            StackSize += size;
        }

        public void UseItem() {
            if (StackSize <= 0) {
                //Item does not exist!
                return;
            }
            //TODO: Use Items effect on intended character
            StackSize--;
        }



    }
}
