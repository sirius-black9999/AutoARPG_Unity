using System;
using Production.Tilemaps;
using UnityEngine;

namespace Production
{
    
    [Serializable]
    public class TilePattern
    {
        public int pattern;
        public int variant;
        public Color32 color;
    }
    public class PatternedTile
    {
        public readonly Vector2 position;
        public TilePattern[] _TileLayers;
    }
}