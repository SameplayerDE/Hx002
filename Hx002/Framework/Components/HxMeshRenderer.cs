using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework.Components
{
    public class HxMeshRenderer : HxRenderer
    {
        public void Render(GraphicsDevice graphicsDevice, HxCamera hxCamera)
        {
            
            if (Material == null)
            {
                return;
            }
            
            if (HxGameObject.Get<HxMeshFilter>() != null)
            {
                HxMesh mesh = HxGameObject.Get<HxMeshFilter>().HxMesh;  

                if (Material.Effect != null)
                {

                    if (mesh.HxMeshData.VertexCount < 3)
                    {
                        return;
                    }

                    Matrix translationMatrix = Matrix.CreateTranslation(HxGameObject.Get<HxTransform>().Position);
                    Matrix rotationMatrix =
                        Matrix.CreateRotationX(MathHelper.ToRadians(HxGameObject.Get<HxTransform>().Rotation.X)) *
                        Matrix.CreateRotationY(MathHelper.ToRadians(HxGameObject.Get<HxTransform>().Rotation.Y)) *
                        Matrix.CreateRotationZ(MathHelper.ToRadians(HxGameObject.Get<HxTransform>().Rotation.Z));
                    Matrix world =  Matrix.CreateScale(HxGameObject.Get<HxTransform>().Scale) * rotationMatrix * translationMatrix;
                    Material.Effect.Parameters["WorldViewProjection"]
                        .SetValue(world * hxCamera.ViewMatrix * hxCamera.ProjectionMatrix);
                    Material.Effect.Parameters["Color"]
                        .SetValue(Material.Color.ToVector4());

                    foreach (EffectPass effectPass in Material.Effect.CurrentTechnique.Passes)
                    {
                        effectPass.Apply();
                        graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, mesh.HxMeshData.VertexData, 0,
                            mesh.HxMeshData.VertexCount / 3);
                    }
                }
            }
        }
    }
}