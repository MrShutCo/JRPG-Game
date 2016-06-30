using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class Character : GameObject {

        public Vector2 Velocity;
        public float Speed;
        KeyboardState keyboard, lastKeyboard;
        float keyRepeatTime;
        float seconds;
        const float keyRepeatDelay = 0.35f;

        public Character(Texture2D texture, Vector2 position, Room room)
            :base (texture,position, room)
        {
            Speed = 1.5f;
            Velocity = Vector2.Zero;
        }

        void KeyPressedDelay(Keys key, Vector2 movement) {

            if (!CheckCollision(Position + movement)) {
                if (keyboard.IsKeyDown(key)) {
                    if (lastKeyboard.IsKeyUp(key) || keyRepeatTime < 0) {
                        keyRepeatTime = keyRepeatDelay;
                         Position += movement;
                        Camera.Pos = Position;
                    }
                    else {
                        keyRepeatTime -= seconds;
                    }
                }
            }
        }

        bool CheckCollision(Vector2 nextPos) {
            foreach (Rectangle r in Room.CollisionLayer.CollisionRectangles) {
                if (new Vector2(r.X,r.Y) == nextPos) {
                    return true;
                }
            }
            return false;
        }

        public override void Update(GameTime gameTime) {
            lastKeyboard = keyboard;
            keyboard = Keyboard.GetState();

            seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboard.IsKeyDown(Keys.Left)) Texture = TexturePool.GetTexture("robot_l");
            if (keyboard.IsKeyDown(Keys.Right)) Texture = TexturePool.GetTexture("robot_r");
            if (keyboard.IsKeyDown(Keys.Up)) Texture = TexturePool.GetTexture("robot_u");
            if (keyboard.IsKeyDown(Keys.Down)) Texture = TexturePool.GetTexture("robot_d");
            KeyPressedDelay(Keys.Left, new Vector2(-32, 0));
            KeyPressedDelay(Keys.Right, new Vector2(32, 0));
            KeyPressedDelay(Keys.Down, new Vector2(0, 32));
            KeyPressedDelay(Keys.Up, new Vector2(0, -32));
        }

    }
}
