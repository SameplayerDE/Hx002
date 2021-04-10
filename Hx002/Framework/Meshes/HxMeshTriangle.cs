using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework.Meshes
{
    public class HxMeshDataTriangle : HxMeshData
    {
        
        public HxMeshDataTriangle() {}
        
        public HxMeshDataTriangle(Vector3 a, Vector3 b, Vector3 c)
        {
            Add(new VertexPositionColor(a, Color.White));
            Add(new VertexPositionColor(b, Color.White));
            Add(new VertexPositionColor(c, Color.White));
        }
        
    }
}