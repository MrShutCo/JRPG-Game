using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TiledSharp;

namespace JRPG_Game {
    public static class MapIO {


        public static Room LoadRoom(string fileName) {
            
            var map = new TmxMap(fileName + ".tmx");
            int width = map.Width;
            int height = map.Height;
            Room newRoom = new Room(fileName, width, height);
            foreach (TmxLayer tmxL in map.Layers) {
                Tile[,] TileLayer = new Tile[width, height];
                switch (tmxL.Name) {
                    case "Ground":
                        foreach (TmxLayerTile tile in tmxL.Tiles)
                            TileLayer[tile.X, tile.Y] = new TileVisible(newRoom, tile.Gid - 1, tile.X, tile.Y, TileType.ground);
                        break;
                    case "Interact":
                        foreach (TmxLayerTile tile in tmxL.Tiles) {
                            if (tile.Gid != 0) TileLayer[tile.X, tile.Y] = new TileVisible(newRoom, tile.Gid - 1, tile.X, tile.Y, TileType.collider);
                            else TileLayer[tile.X, tile.Y] = new TileVisible(newRoom, tile.Gid - 1, tile.X, tile.Y, TileType.other);
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
                            TileLayer[(int)obj.X / 32, (int)obj.Y / 32] = new TileTeleporter(newRoom, obj.Properties["room"], (int)obj.X/ 32, (int)obj.Y/32, Convert.ToInt32(obj.Properties["X"]), Convert.ToInt32(obj.Properties["Y"]), TileType.teleporter);
                        }
                        break;
                }
                newRoom.AddTileLayer(tmxO.Name, new TileLayer(newRoom, TileLayer));
            }
            //Maybe change to Just add to RoomManager
            return newRoom;
        }
    }
}

