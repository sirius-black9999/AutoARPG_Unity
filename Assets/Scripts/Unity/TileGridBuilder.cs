using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Production;
using Production.Tilemaps;
using UnityEngine;
using UnityEngine.Serialization;

namespace BW_Unity
{
    public class TileGridBuilder : MonoBehaviour
    {
        private readonly SubTiler _autoTile = new();
        private readonly MeshGen _generator = new();
        public Mesh target;
        public Vector3 posOffset;
        public Vector3 scaleOffset;

        public TileMapping[] mapping;

        private Func<Vector3, Vector3> Rescale => pos =>
            new Vector3(pos.x * scaleOffset.x, pos.y * scaleOffset.y, pos.z * scaleOffset.z) + posOffset;

        public void Generate(TileMap<SimpleTile> drawnMap)
        {
            var colPatternMap = _autoTile.SubTile(drawnMap);
            var meshMap = _generator.Meshify(colPatternMap);
            target.SetVertices(meshMap.Tiles.SelectMany(tile => tile.Pos.Select(Rescale)).ToArray());
            target.SetUVs(0, meshMap.Tiles.SelectMany(tile => tile.UVs).ToArray());
            target.SetColors(meshMap.Tiles.SelectMany(tile => tile.Cols).ToArray());
            target.SetIndices(Enumerable.Range(0, target.vertexCount).ToArray(), MeshTopology.Triangles, 0);
        }
    }
}