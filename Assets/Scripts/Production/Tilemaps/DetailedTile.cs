using System;
using UnityEngine;

namespace Production
{
    public struct Vertex
    {
        public Vector2 uv { get; private set; }
        public Color32 col { get; private set; }
        public Vector3 pos { get; private set; }
        public Vertex WithUv(Vector2 newUv) => new() {uv = newUv, col = col, pos = pos};
        public Vertex WithCol(Color32 newCol) => new() {uv = uv, col = newCol, pos = pos};
        public Vertex WithPos(Vector3 newPos) => new() {uv = uv, col = col, pos = newPos};
    }

    public class DetailedTile
    {
        private readonly Vertex Xn_Yn;
        private readonly Vertex Xp_Yn;
        private readonly Vertex Xn_Yp;
        private readonly Vertex Xp_Yp;

        public DetailedTile(params Vertex[] verts)
        {
            if (verts.Length != 4)
                throw new ArgumentException($"DetailedTile constructor expects exactly 4 vertices, not {verts.Length}");
            Xn_Yn = verts[0];
            Xp_Yn = verts[1];
            Xn_Yp = verts[2];
            Xp_Yp = verts[3];
        }

        public DetailedTile()
        {
            Xn_Yn = new Vertex();
            Xp_Yn = new Vertex();
            Xn_Yp = new Vertex();
            Xp_Yp = new Vertex();
        }

        private T[] MakeTris<T>(Func<Vertex, T> transform) =>
            new[]
            {
                transform(Xn_Yn), transform(Xn_Yp), transform(Xp_Yn),
                transform(Xp_Yp), transform(Xp_Yn), transform(Xn_Yp)
            };

        public Vector2[] UVs => MakeTris(vertex => vertex.uv);
        public Color32[] Cols => MakeTris(vertex => vertex.col);
        public Vector3[] Pos => MakeTris(vertex => vertex.pos);
    }
}