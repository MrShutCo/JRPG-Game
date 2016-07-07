using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class InputHandler {

         Dictionary<Keys, Action> KeyMappings = new Dictionary<Keys, Action>();

         KeyboardState keyboardState;
         KeyboardState previousKeyboardState;

        public  bool KeyPressed(Keys key) {
            return (keyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key));
        }

        public  bool KeyReleased(Keys key) {
            return (keyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key));
        }

         void UpdateKey() {
            keyboardState = Keyboard.GetState();
        }

         void UpdateLastKey() {
            previousKeyboardState = keyboardState;
        }

        public  void RegisterKey(Keys key, Action action) {
            KeyMappings[key] = action;
        }

        //This will be filled with the proper Key events and actions for each state
        public  void Update(GameTime gameTime) {
            UpdateKey();
            foreach (KeyValuePair<Keys, Action> mapping in KeyMappings) {
                 if (keyboardState.IsKeyDown(mapping.Key))
                 mapping.Value();
            }
            UpdateLastKey();
        }

    }
}
