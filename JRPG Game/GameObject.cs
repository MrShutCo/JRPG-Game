using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class GameObject {

        public Texture2D Texture;
        public Vector2 Position;
        public Room Room;
        int X;
        int Y;

        public GameObject(Texture2D texture, Room room, int x, int y) {
            Texture = texture;
            X = x;
            Y = y;
            Room = room;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize), Color.White);
        }

        public virtual void Update(GameTime gameTime) {
            
        }


    }
}
