using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JRPG_Game {
    public static class MapIO {


        public static Room LoadRoom(string fileName) {

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode MapData = doc.DocumentElement.SelectSingleNode("/map");
            int width = Convert.ToInt32(MapData.Attributes["width"].Value);
            int height = Convert.ToInt32(MapData.Attributes["height"].Value);
            Room newRoom = new Room(width, height);
            bool collider = false;
            XmlNode TileSet = doc.DocumentElement.SelectSingleNode("/map/tilesets");
            XmlNodeList Layers = doc.DocumentElement.SelectNodes("/map/layer");
            foreach (XmlNode node in Layers) {
                //Now im in the layer, but i need to pass the data to get the tile
                int[] tileLayout = new int[width * height];
                var properties = node.FirstChild;
                var data = node.LastChild;
                
                int counter = 0;

                foreach (XmlNode property in properties) {
                    if (property.Attributes["name"].Value == "Collider") {
                        if (property.Attributes["value"].Value == "true") {
                            collider = true;
                        }
                        else collider = false;
                    }

                }
               if (!collider) {
                    foreach (XmlNode tile in data) {
                        tileLayout[counter] = Convert.ToInt32(tile.Attributes["gid"].Value) - 1;
                        counter++;
                    }
                    TileLayer layer = new TileLayer(newRoom, tileLayout);
                    newRoom.AddTileLayer(node.Attributes["name"].Value, layer);
                }
                else {
                    int x = 0, y = 0;
                    foreach (XmlNode tile in data) {
                        if (x >= width * 32) {
                            x = 0;
                            y += 32;
                        }
                        if (tile.Attributes["gid"].Value != "0") {
                            newRoom.AddCollider(new Rectangle(x, y, x + 32, y + 32));
                        }
                        x += 32;
                        tileLayout[counter] = Convert.ToInt32(tile.Attributes["gid"].Value) - 1;
                        counter++;
                    }
                    TileLayer layer = new TileLayer(newRoom, tileLayout);
                    newRoom.AddTileLayer(node.Attributes["name"].Value, layer);
                }
            }
            return newRoom;
        }
    }
}

