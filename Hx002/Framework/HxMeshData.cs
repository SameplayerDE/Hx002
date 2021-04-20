using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxMeshData
    {
        public VertexPositionNormalTexture[] VertexData
        {
            get { return _vertexData.ToArray(); }
        }
        public List<VertexPositionNormalTexture> _vertexData = new List<VertexPositionNormalTexture>();

        public HxMeshData()
        {
            
        }

        public HxMeshData Copy()
        {
            HxMeshData data = new HxMeshData();
            data.Add(this);
            return data;
        }

        public void Add(VertexPositionNormalTexture vertex)
        {
            _vertexData.Add(vertex);
        }
        
        public void Add(HxMeshData data)
        {
            _vertexData.AddRange(data.VertexData);
        }

        public HxMeshData Clone()
        {
            return (HxMeshData) this.MemberwiseClone();
        }
    }
}