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

        public GameObject(Texture2D texture, Vector2 position, Room room) {
            Texture = texture;
            Position = position;
            Room = room;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y), Color.White);
        }

        public virtual void Update(GameTime gameTime) {
            
        }


    }
}
