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
            
            var map = new TmxMap(fileName);
            int width = map.Width;
            int height = map.Height;
            Room newRoom = new Room(width, height);
            foreach (TmxLayer tmxL in map.Layers) {
                Tile[,] TileLayer = new Tile[width, height];
                if (tmxL.Properties["Collider"] == "true") {
                    foreach (TmxLayerTile tile in tmxL.Tiles) {
                        if (tile.Gid != 0) TileLayer[tile.X, tile.Y] = new Tile(newRoom, tile.Gid - 1, tile.X, tile.Y, TileType.collider);
                        else TileLayer[tile.X, tile.Y] = new Tile(newRoom, tile.Gid - 1, tile.X, tile.Y, TileType.other);
                    }
                }
                else { 
                    foreach (TmxLayerTile tile in tmxL.Tiles)
                        TileLayer[tile.X, tile.Y] = new Tile(newRoom, tile.Gid - 1, tile.X, tile.Y, TileType.ground);
                }
                newRoom.AddTileLayer(tmxL.Name, new TileLayer(newRoom, TileLayer));
            }
            return newRoom;
        }
    }
}

