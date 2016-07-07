using JRPG_Game.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public static class InputHandler {

        static Dictionary<Keys, Action> KeyMappings = new Dictionary<Keys, Action>();

        static KeyboardState keyboardState;
        static KeyboardState previousKeyboardState;

        static bool KeyPressed(Keys key) {
            return (keyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key));
        }

        static bool KeyReleased(Keys key) {
            return (keyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key));
        }
        
        static void UpdateKey() {
            keyboardState = Keyboard.GetState();
        }

        static void UpdateLastKey() {
            previousKeyboardState = keyboardState;
        }

        public static void RegisterKey(Keys key, Action action) {
            KeyMappings[key] = action;
        }

        //This will be filled with the proper Key events and actions for each state
        public static void Update(GameTime gameTime) {
            UpdateKey();
            foreach (KeyValuePair<Keys, Action> mapping in KeyMappings) {
                if (KeyPressed(mapping.Key))
                    mapping.Value();
            }
            UpdateLastKey();
        }

    }
}
