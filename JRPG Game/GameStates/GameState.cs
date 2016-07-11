using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JRPG_Game.GUI_Objects;
using JRPG_Game.Managers;

namespace JRPG_Game.GameStates {
    class GameState : IState {

        public StateStack stateStack { get; set; }
        InputHandler handler;

        public void OnEnter() {
            MapIO.ReadMapsFolder();
            handler = new InputHandler();
            RoomManager.SetRoom("New Test1");
            RoomManager.CurrentRoom.Character = new Character(TexturePool.GetTexture("robot_l"), RoomManager.CurrentRoom, 4, 8);
            StatManager.Stats = new Stat("MrShutCo", 100, 50, 10, 7, 5, 0, 0);
            Camera.Pos = new Vector2(RoomManager.CurrentRoom.Character.X * 32, RoomManager.CurrentRoom.Character.Y * 32);
            StatViewer CarStat = new StatViewer();
            GUIManager.GUIObjects["stats"] = CarStat;
            handler.RegisterKey(Keys.Back, MenuEnter);
        }

        public void OnExit() {
            
        }

        void MenuEnter() {
            stateStack.Push("menu");
        }

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,null,Camera.viewMatrix);
            RoomManager.CurrentRoom.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            GUIManager.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime) {
            handler.Update(gameTime);
            RoomManager.CurrentRoom.Update(gameTime);
        }
    }
}
