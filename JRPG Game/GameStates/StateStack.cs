using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GameStates {
    public class StateStack {

        Dictionary<string, IState> mStates = new Dictionary<string, IState>();
        Stack<IState> mStack = new Stack<IState>();

        public void Update(GameTime gameTime) {
            IState top = mStack.First();
            top.Update(gameTime);
        }

        public void Add(string name, IState state) {
            mStates[name] = state;
            mStates[name].stateStack = this;
        }

        public void Render(SpriteBatch spriteBatch) {
            IState top = mStack.First();
            top.Render(spriteBatch);
        }

        public void Push(String name) {
            IState state = mStates[name];
            mStack.Push(state);
            state.OnEnter();
        }

        public IState Pop() {
            mStack.First().OnExit();
            return mStack.Pop();
        }

    }
}
