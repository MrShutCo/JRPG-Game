using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GameStates {
    class StateManager {

        public StateStack stateStack { get; set; }

        Dictionary<string, IState> mStates = new Dictionary<string, IState>();
        IState mCurrentState = new EmptyState();

        public void Update(GameTime gameTime) {
            mCurrentState.Update(gameTime);
        }

        public void Render(SpriteBatch spriteBatch) {
            mCurrentState.Render(spriteBatch);
        }

        public void Change(string name, params object[] parameters) {
            mCurrentState.OnExit();
            mCurrentState = mStates[name];
            
        }

        public void Add(string name, IState state) {
            mStates[name] = state;
        }

    }
}
