using System;

namespace Production.Tilemaps
{
    [Serializable]
    public class TileMapping
    {
        public int fromIndex;
        public TilePattern[] toTiles;
    }
}