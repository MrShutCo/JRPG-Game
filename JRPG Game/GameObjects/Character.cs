using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {

    public enum EDirection {
        North,
        East,
        West,
        South
    }

    public class Character : GameObject {

        public Vector2 Velocity;
        public float Speed;
        KeyboardState keyboard, lastKeyboard;

        public EDirection Direction;

        float keyRepeatTime;
        float seconds;
        const float keyRepeatDelay = 0.35f;


        public Character(Texture2D texture, Room room, int x, int y)
            :base (texture,room,x,y)
        {
            Speed = 1.5f;
            Velocity = Vector2.Zero;
            Direction = EDirection.East;
        }
        void KeyPressedDelay(Keys key, int xMove, int yMove) {

            if (!CheckCollision(X + xMove, Y + yMove)) {
                if (keyboard.IsKeyDown(key)) {
                    if (lastKeyboard.IsKeyUp(key) || keyRepeatTime < 0) {
                        keyRepeatTime = keyRepeatDelay;
                        X += xMove;
                        Y += yMove;
                        Camera.Pos = new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize);
                    }
                    else {
                        keyRepeatTime -= seconds;
                    }
                }
                TileTeleporter test = (TileTeleporter)Room.TileLayers["Events"].GetTileAt(X, Y);
                if (test != null) {
                    if (test.TileType == TileType.teleporter) {
                        test.Teleport();
                    }
                }
            }
        }

        bool CheckCollision(int x, int y) {
            if (Room.TileLayers["Interact"].TileLayout[x, y].TileType == TileType.collider) {
                return true;
            }
            return false;
        }

        void InspectInFront() {
            TileSign Inspected = null;
            int newX = X;
            int newY = Y;
            switch (Direction) {
                case EDirection.North:
                    newY--;
                    break;
                case EDirection.East:
                    newX++;
                    break;
                case EDirection.West:
                    newX--;
                    break;
                case EDirection.South:
                    newY++;
                    break;

            }
            Inspected = (TileSign)Room.TileLayers["Events"].TileLayout[newX,newY];
            if (Inspected.TileType == TileType.readable) {
                Inspected.LookAt();
            }
        }

        public override void Update(GameTime gameTime) {
            lastKeyboard = keyboard;
            keyboard = Keyboard.GetState();

            seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //TODO: Clean up to proper input handling
            if (keyboard.IsKeyDown(Keys.Enter)) {
                InspectInFront();
            }
            if (keyboard.IsKeyDown(Keys.Left)) {
                Direction = EDirection.West;
                Texture = TexturePool.GetTexture("robot_l");
                KeyPressedDelay(Keys.Left, -1, 0);
            }
            if (keyboard.IsKeyDown(Keys.Right)){
                Direction = EDirection.East;
                Texture = TexturePool.GetTexture("robot_r");
                KeyPressedDelay(Keys.Right, 1, 0);
            }
            if (keyboard.IsKeyDown(Keys.Up)) {
                Direction = EDirection.North;
                Texture = TexturePool.GetTexture("robot_u");
                KeyPressedDelay(Keys.Up, 0, -1);
            }
            if (keyboard.IsKeyDown(Keys.Down)) {
                Direction = EDirection.South;
                Texture = TexturePool.GetTexture("robot_d");
                KeyPressedDelay(Keys.Down, 0, 1);
            }
            
        }

    }
}
