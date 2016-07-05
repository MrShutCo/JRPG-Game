using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game {
    public class TileSheet {

        public Texture2D[] TextureSheet;
        public string name;
        GraphicsDevice GraphicsDevice;
        public int GID;

        public void SetGID(int gid) {
            GID = gid;
        }

        public TileSheet(GraphicsDevice graphics, Texture2D texturesheet, int xSize, int ySize) {
            GraphicsDevice = graphics;
            TextureSheet = SplitTexture(texturesheet, xSize, ySize);
        }

        Texture2D[] SplitTexture(Texture2D tileSheet, int xJ, int yJ) {
            Texture2D[] texList = new Texture2D[tileSheet.Width / xJ * tileSheet.Height / yJ];
            int counter = 0;
            for (int y = 0; y < tileSheet.Height; y += yJ) {
                for (int x = 0; x < tileSheet.Width; x += xJ) {
                    Rectangle tempRec = new Rectangle(x, y, xJ, yJ);
                    Texture2D tempTex = new Texture2D(GraphicsDevice, tempRec.Width, tempRec.Height);
                    Color[] tempData = new Color[tempRec.Width * tempRec.Height];
                    tileSheet.GetData(0, tempRec, tempData, 0, tempData.Length);
                    tempTex.SetData(tempData);
                    texList[counter] = tempTex;
                    counter++;

                }
            }
            return texList;
        }

    }
}
