using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TiledSharp;

namespace JRPG_Game {
    public static class MapIO {

        public static void ReadMapsFolder() {
            string[] rooms = Directory.GetFiles("../../../../maps/", "*.tmx");
            List<string> roomss = new List<string>();
            foreach (string r in rooms) {
                //Might mess things up, not sure
                roomss.Add(r.TrimEnd('.', 't', 'm', 'x'));
            }
            foreach (string s in roomss) {
                LoadRoom(s);
            }
        }

        

        public static void LoadRoom(string fileName) {
            var map = new TmxMap(fileName + ".tmx");
            int width = map.Width;
            int height = map.Height;
            Room newRoom = new Room(fileName, width, height);

            foreach(TmxTileset tmxT in map.Tilesets) {

                newRoom.AddTileSheet(tmxT.Name, TexturePool.GetTileSheet(tmxT.Name));
                newRoom.TileSheets[tmxT.Name].SetGID(tmxT.FirstGid);
            }
            TileSheet currSheet = null;
            foreach (TmxLayer tmxL in map.Layers) {
                Tile[,] TileLayer = new Tile[width, height];
                switch (tmxL.Name) {
                    case "Ground":
                        
                        foreach (TmxLayerTile tile in tmxL.Tiles) {
                            int lastGID = 0;
                            int thisGID = 0;
                            if (tile.Gid != 0) {
                                foreach (KeyValuePair<string, TileSheet> kvp in newRoom.TileSheets) {
                                    thisGID = kvp.Value.GID;
                                    if (tile.Gid > thisGID) {
                                        currSheet = kvp.Value;

                                    }
                                }
                                TileLayer[tile.X, tile.Y] = new TileVisible(newRoom, currSheet, tile.Gid - currSheet.GID, tile.X, tile.Y, TileType.ground);
                            }
                        }
                        break;
                    case "Interact":
                        foreach (TmxLayerTile tile in tmxL.Tiles) {
                            int lastGID = 0;
                            int thisGID = 0;
                            if (tile.Gid != 0) {
                                foreach (KeyValuePair<string, TileSheet> kvp in newRoom.TileSheets) {
                                    thisGID = kvp.Value.GID;
                                    if (tile.Gid >= thisGID) {
                                        currSheet = kvp.Value;

                                    }
                                }
                                TileLayer[tile.X, tile.Y] = new TileVisible(newRoom, currSheet, tile.Gid - currSheet.GID, tile.X, tile.Y, TileType.collider);
                            }
                            else TileLayer[tile.X, tile.Y] = new TileVisible(newRoom, currSheet, tile.Gid - 1, tile.X, tile.Y, TileType.other);
                        }
                        break;
                }
                newRoom.AddTileLayer(tmxL.Name, new TileLayer(newRoom, TileLayer));
            }
            foreach (TmxObjectGroup tmxO in map.ObjectGroups) {
                Tile[,] TileLayer = new Tile[width, height];
                switch (tmxO.Name) {
                    case "Events":
                        foreach (TmxObject obj in tmxO.Objects) {
                            var type = obj.Properties["Type"];
                            switch (type) {
                                case "Teleporter":
                                    TileLayer[(int)obj.X / 32, (int)obj.Y / 32] = new TileTeleporter(newRoom, obj.Properties["room"], (int)obj.X / 32, (int)obj.Y / 32, Convert.ToInt32(obj.Properties["X"]), Convert.ToInt32(obj.Properties["Y"]), TileType.teleporter);
                                    break;
                                case "Readable":
                                    TileLayer[(int)obj.X / 32, (int)obj.Y / 32] = new TileSign(newRoom, obj.Properties["text"], (int)obj.X / 32, (int)obj.Y / 32, TileType.readable);
                                    break;
                            }
                            
                        }
                        break;
                }
                newRoom.AddTileLayer(tmxO.Name, new TileLayer(newRoom, TileLayer));
            }
            //Maybe change to Just add to RoomManager
            newRoom.Name = Path.GetFileName(newRoom.Name);
            RoomManager.AddRoom(newRoom);
        }
    }
}

