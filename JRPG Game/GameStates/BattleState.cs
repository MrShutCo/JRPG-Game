using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JRPG_Game.Battle;

namespace JRPG_Game.GameStates {

    public enum BattleStates {
        Start,
        PlayerChoice,
        EnemyChoice,
        Lose,
        Win
    }

    class BattleState : IState {

        public BattleState() {

        }

        List<Entity> Enemies;

        Entity Character;

        BattleStates currentStates;

        public StateStack stateStack { get; set; }

        public void OnEnter() {
            currentStates = BattleStates.Start;
            //TODO, load up stats
        }

        public void OnExit() {
            //TODO, If win, then add XP and Gold
        }

        public void Render(SpriteBatch spriteBatch) {
            
        }

        public void Update(GameTime gameTime) {
            switch (currentStates) {
                case BattleStates.Start:
                    break;
                case BattleStates.PlayerChoice:
                    break;
                case BattleStates.EnemyChoice:
                    break;
                case BattleStates.Win:
                    break;
                case BattleStates.Lose:
                    break;
            }
        }
    }
}
