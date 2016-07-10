using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {

    public struct Stat {
        public Stat(string name, int hP, int mP, int atk, int def, int spd, int gold, int xp) : this() {
            Name = name;
            HP = hP;
            MP = mP;
            Atk = atk;
            Def = def;
            Spd = spd;
            Gold = gold;
            Xp = xp;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }
        public int Gold { get; set; }
        public int Xp { get; set; }

    }

    public class GameObject {

        public Texture2D Texture;
        public int X, Y;
        public Room Room;

        public GameObject(Texture2D texture, Room room, int x, int y) {
            Texture = texture;
            X = x;
            Y = y;
            Room = room;
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize), Color.White);
        }

        public virtual void Update(GameTime gameTime) {
            
        }


    }
}
