using JRPG_Game.GUI_Objects;
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
        public InputHandler InputHandler;

        public EDirection Direction;

        float keyRepeatTime;
        float seconds;
        const float keyRepeatDelay = 0.35f;
        bool canMove;

        public Character(Texture2D texture, Room room, int x, int y)
            :base (texture,room,x,y)
        {
            Speed = 1.5f;
            Velocity = Vector2.Zero;
            Direction = EDirection.East;
            InputHandler = new InputHandler();
            InputHandler.RegisterKey(Keys.Left, moveLeft);
            InputHandler.RegisterKey(Keys.Right, moveRight);
            InputHandler.RegisterKey(Keys.Up, moveUp);
            InputHandler.RegisterKey(Keys.Down, moveDown);
            InputHandler.RegisterKey(Keys.Enter, InspectInFront);
            Camera.Pos = new Vector2(X * Room.TilePixelSize, Y * Room.TilePixelSize);
            canMove = true;
        }

        void KeyPressedDelay(Keys key, int xMove, int yMove) {
            if (!canMove) return;
            if (!CheckCollision(X + xMove, Y + yMove)) {
                if (InputHandler.KeyPressed(key) || keyRepeatTime < 0) {
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
                    test.Teleport(this);
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
            if (Inspected != null)
                if (Inspected.TileType == TileType.readable) {
                    if (GUIManager.currentConversation == null) {
                        Inspected.LookAt();
                        canMove = false;
                    }
                    else {
                        var conv = GUIManager.currentConversation;
                        if (conv.convNo >= conv.Text.Count - 1) {
                            conv = null;
                            canMove = true;
                        }
                        else {
                            conv.NextTextBox();
                        }
                        GUIManager.currentConversation = conv;
                    }
                }
             }

        public void moveLeft() {
            Direction = EDirection.West;
            Texture = TexturePool.GetTexture("robot_l");
            KeyPressedDelay(Keys.Left, -1, 0);
        }

        public void moveRight() {
            Direction = EDirection.East;
            Texture = TexturePool.GetTexture("robot_r");
            KeyPressedDelay(Keys.Right, 1, 0);
        }

        public void moveUp() {
            Direction = EDirection.North;
            Texture = TexturePool.GetTexture("robot_u");
            KeyPressedDelay(Keys.Up, 0, -1);
        }

        public void moveDown() {
            Direction = EDirection.South;
            Texture = TexturePool.GetTexture("robot_d");
            KeyPressedDelay(Keys.Down, 0, 1);
        }


        public override void Update(GameTime gameTime) {
            InputHandler.Update(gameTime);
            seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //TODO: Clean up to proper input handling
            if (keyboard.IsKeyDown(Keys.Enter)) {
                //InspectInFront();
            }
            
        }

    }
}
