using System.Collections.Generic;

namespace Production
{
    public class TileMap<T> where T : new()
    {
        private readonly T[] _tiles;
        public IEnumerable<T> Tiles => _tiles;
        public int Width { get; }
        public int Height { get; }

        public T this[int x, int y]
        {
            get => _tiles[x + y * Width];
            set => _tiles[x + y * Width] = value;
        }

        public TileMap(int x, int y)
        {
            _tiles = new T[x * y];
            Width = x;
            Height = y;

            for (var index = 0; index < _tiles.Length; index++)
            {
                _tiles[index] = new T();
            }
        }
    }
}