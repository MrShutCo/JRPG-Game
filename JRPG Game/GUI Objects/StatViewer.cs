using JRPG_Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.GUI_Objects {
    public class StatViewer : GUIObject {

        //TODO: Make this look nice, maybe add more detail and niceness

        public StatViewer() {
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), "Name: " + StatManager.Stats.Name, new Vector2(32,32), Color.Black);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), "HP: " + StatManager.Stats.HP.ToString(), new Vector2(32, 52), Color.Black);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), "MP: " + StatManager.Stats.MP.ToString(), new Vector2(32, 72), Color.Black);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), "Gold: " + StatManager.Stats.Gold.ToString(), new Vector2(32, 92), Color.Black);
            spriteBatch.DrawString(TexturePool.GetFont("dialogue_font"), "Xp: " + StatManager.Stats.Xp.ToString(), new Vector2(32, 112), Color.Black);
        }

    }
}
