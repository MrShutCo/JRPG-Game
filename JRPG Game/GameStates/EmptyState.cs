using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GameStates {

    public interface IState {
        StateStack stateStack { get; set; }
        void Update(GameTime gameTime);
        void Render(SpriteBatch spriteBatch);
        void OnEnter();
        void OnExit();
    }

    class EmptyState : IState {
        public StateStack stateStack { get; set; }

        public void Update(GameTime gameTime) {

        }
        public void Render(SpriteBatch spriteBatch) {

        }
        public void OnEnter() {
        }

        public void OnExit() {
          
        }
    }
}
