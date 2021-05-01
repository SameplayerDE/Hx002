using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework.Components
{
    public class HxMeshRenderer : HxRenderer
    {
        public void Render(GraphicsDevice graphicsDevice, HxCamera hxCamera)
        {
            if (HxGameObject.Get<HxMeshFilter>() != null)
            {
                HxMesh mesh = HxGameObject.Get<HxMeshFilter>().HxMesh;

                if (mesh.Effect != null)
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
                    Matrix world = rotationMatrix * translationMatrix * Matrix.CreateScale(HxGameObject.Get<HxTransform>().Scale);
                    mesh.Effect.Parameters["WorldViewProjection"]
                        .SetValue(world * hxCamera.ViewMatrix * hxCamera.ProjectionMatrix);

                    foreach (EffectPass effectPass in mesh.Effect.CurrentTechnique.Passes)
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