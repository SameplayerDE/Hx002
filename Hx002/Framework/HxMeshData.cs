using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxMeshData
    {
        public VertexPositionColor[] VertexData
        {
            get { return _vertexData.ToArray(); }
        }
        public List<VertexPositionColor> _vertexData = new List<VertexPositionColor>();

        public HxMeshData()
        {
            
        }

        public void Add(VertexPositionColor vertex)
        {
            _vertexData.Add(vertex);
        }
        
        public void Add(HxMeshData data)
        {
            _vertexData.AddRange(data.VertexData);
        }
    }
}