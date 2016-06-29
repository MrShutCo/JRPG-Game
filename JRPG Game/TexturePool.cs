using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public static class TexturePool {

        static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        static Dictionary<string, TileSheet> TileSheets = new Dictionary<string, TileSheet>();

        public static void AddTexture(string name, Texture2D texture) {
            Textures[name] = texture;
        }

        public static void AddTileSheet(string name, TileSheet tileSheet) {
            TileSheets[name] = tileSheet;
        }

        public static Texture2D GetTexture(string name) {
            return Textures[name];
        }

        public static TileSheet GetTileSheet(string name) {
            return TileSheets[name];
        }


    }
}
