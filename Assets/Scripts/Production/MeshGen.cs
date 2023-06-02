using System.Linq;
using Production.Tilemaps;
using UnityEngine;

namespace Production
{
    public class MeshGen
    {
        public TileMap<DetailedTile> Meshify(TileMap<PatternedTile> colPatternMap)
        {
            var result = colPatternMap.Tiles.SelectMany(Convert).ToArray();
            TileMap<DetailedTile> returned = new TileMap<DetailedTile>(result.Length, 1);
            for (int i = 0; i < result.Length; i++)
            {
                returned[i, 0] = result[i];
            }

            return returned;
        }

        private DetailedTile[] Convert(PatternedTile tile)
        {
            var returned = new DetailedTile[tile._TileLayers.Length];
            for (var index = 0; index < tile._TileLayers.Length; index++)
            {
                var tilePos = new Vector3(tile.position.x, tile.position.y, index);
                returned[index] = CreateMesh(tilePos, tile._TileLayers[index]);
            }

            return returned;
        }

        private DetailedTile CreateMesh(Vector3 tilePosition, TilePattern tileDetails)
        {
            var Xn_Yn = new Vertex().WithPos(tilePosition);
            var Xp_Yn = new Vertex().WithPos(tilePosition + new Vector3(1, 0));
            var Xn_Yp = new Vertex().WithPos(tilePosition + new Vector3(0, 1));
            var Xp_Yp = new Vertex().WithPos(tilePosition + new Vector3(1, 1));

            //TODO: retrieve col from details
            //TODO: retrieve UVs from tilemap using details

            return new DetailedTile(Xn_Yn, Xp_Yn, Xn_Yp, Xp_Yp);
        }
    }
}