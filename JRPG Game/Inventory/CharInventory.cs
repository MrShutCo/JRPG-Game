using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Inventory {
    public class CharInventory {

        public List<ItemStack> Items;

        public CharInventory() {
            Items = new List<ItemStack>();
        }

        public void AddItem(Item item, int number) {
            foreach (ItemStack i in Items) {
                if (i.Item.Name == item.Name) {
                    //at least one exists
                    if (i.StackSize == 100) continue;
                    if (i.StackSize + number > 99) {
                        //Stack is full, create a new one once this is complete
                        int overflow = i.StackSize + number - 100;
                        i.StackSize = 100;
                        Items.Add(new ItemStack(item, overflow));
                        return;
                    }
                    else {
                        i.AddItem(number);
                        return;
                    }
                }
            }
            //IF we're here, that means there isnt a pre-existing stack, so lets make it
            Items.Add(new ItemStack(item, number));
        }

    }
}
