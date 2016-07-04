﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JRPG_Game.GameStates {
    class GameState : IState {

        public StateStack stateStack { get; set; }

        public void OnEnter() {
            RoomManager.CurrentRoom = MapIO.LoadRoom("New Test");
            RoomManager.AddRoom(MapIO.LoadRoom("New Test"));
            RoomManager.AddRoom(MapIO.LoadRoom("New Test2"));
            RoomManager.CurrentRoom.AddTileSheet("world", TexturePool.GetTileSheet("testsheet"));
            RoomManager.CurrentRoom.Character = new Character(TexturePool.GetTexture("robot_l"), RoomManager.CurrentRoom, 2, 2);
            Camera.Pos = new Vector2(128,128);
        }

        public void OnExit() {
            
        }

        

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,null,Camera.viewMatrix);
            RoomManager.CurrentRoom.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime) {
            RoomManager.CurrentRoom.Update(gameTime);
        }
    }
}
