using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxMesh : HxObject
    {
        private HxMeshData _data = new HxMeshData();

        public HxMesh() {}

        public HxMesh(HxMeshData data)
        {
            _data = data;
        }
        
        public void Add(VertexPositionColor data)
        {
            _data.Add(data);
        }
        
        public void Add(HxMeshData data)
        {
            _data.Add(data);
        }
        
        public void Draw(GraphicsDevice graphicsDevice, Effect effect, Matrix world, Matrix view, Matrix projection)
        {
            world = Matrix.CreateTranslation(Vector3);
            effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);
            
            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _data.VertexData, 0, 1);
            }
        }
        
        public void Draw(GraphicsDevice graphicsDevice, Effect effect, Matrix world, HxCamera hxCamera)
        {
            world = Matrix.CreateTranslation(Vector3);
            effect.Parameters["WorldViewProjection"].SetValue(world * hxCamera.ViewMatrix * hxCamera.ProjectionMatrix);
            
            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _data.VertexData, 0, 1);
            }
        }
        
    }
}