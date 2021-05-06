using System.Collections.Generic;
using Hx002.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxMesh : HxGameObject
    {
        public HxMeshData HxMeshData = new HxMeshData();
        
        public HxMesh() 
        {
            Attach(new HxTransform());
        }

        public HxMesh(HxMeshData data) : this()
        {
            HxMeshData = data;
        }


        public override object Clone()
        {
            var clone = (HxMesh)base.Clone();
            clone.HxMeshData = this.HxMeshData;
            return clone;
        }
        
        protected override HxObject Create()
        {
            return new HxMesh();
        }

        public void Add(VertexPositionNormalTexture data)
        {
            HxMeshData.Add(data);
        }
        
        public void Add(HxMeshData data)
        {
            HxMeshData.Add(data);
        }
        
        public void Draw(GraphicsDevice graphicsDevice, Effect effect, Matrix view, Matrix projection)
        {
            if (HxMeshData.VertexCount < 3)
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
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, HxMeshData.VertexData, 0, HxMeshData.VertexCount / 3);
            }
        }
        
        public void Draw(GraphicsDevice graphicsDevice, Effect effect, HxCamera hxCamera)
        {
            if (HxMeshData.VertexCount < 3)
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
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, HxMeshData.VertexData, 0, HxMeshData.VertexCount / 3);
            }
        }
        
    }
}