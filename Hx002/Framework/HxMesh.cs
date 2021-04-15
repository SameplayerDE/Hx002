using System.Collections.Generic;
using Hx002.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxMesh : HxGameObject
    {
        private HxMeshData _data = new HxMeshData();

        private int _vertexCount
        {
            get { return _data.VertexData.Length; }
        }

        public HxMesh()
        {
            Attach(new HxTransform());
        }

        public HxMesh(HxMeshData data) : this()
        {
            _data = data;
        }
        
        public void Add(VertexPositionNormalTexture data)
        {
            _data.Add(data);
        }
        
        public void Add(HxMeshData data)
        {
            _data.Add(data);
        }
        
        public void Draw(GraphicsDevice graphicsDevice, Effect effect, Matrix view, Matrix projection)
        {
            if (_vertexCount < 3)
            {
                return;
            }
            Matrix translationMatrix = Matrix.CreateTranslation(Get<HxTransform>().Position);
            Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(Get<HxTransform>().Rotation.X)) *
                                    Matrix.CreateRotationY(MathHelper.ToRadians(Get<HxTransform>().Rotation.Y)) *
                                    Matrix.CreateRotationZ(MathHelper.ToRadians(Get<HxTransform>().Rotation.Z));
            Matrix world = rotationMatrix * translationMatrix;
            effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);
            
            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _data.VertexData, 0, _data.VertexData.Length / 3);
            }
        }
        
        public void Draw(GraphicsDevice graphicsDevice, Effect effect, HxCamera hxCamera)
        {
            if (_vertexCount < 3)
            {
                return;
            }

            Matrix translationMatrix = Matrix.CreateTranslation(Get<HxTransform>().Position);
            Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(Get<HxTransform>().Rotation.X)) *
                                    Matrix.CreateRotationY(MathHelper.ToRadians(Get<HxTransform>().Rotation.Y)) *
                                    Matrix.CreateRotationZ(MathHelper.ToRadians(Get<HxTransform>().Rotation.Z));
            Matrix world = rotationMatrix * translationMatrix;
            effect.Parameters["WorldViewProjection"].SetValue(world * hxCamera.ViewMatrix * hxCamera.ProjectionMatrix);
            
            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _data.VertexData, 0, _data.VertexData.Length / 3);
            }
        }
        
    }
}