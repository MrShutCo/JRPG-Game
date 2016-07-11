using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Inventory {
    public class Item {

        public Texture2D itemImage;
        public string Info;
        public string Name;
        public int itemID;

        public Item(Texture2D texture, string name) {
            itemImage = texture;
            Name = name;
        }


    }
}
