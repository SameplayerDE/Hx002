using Hx002.Framework.Enumerations;
using Microsoft.Xna.Framework;

namespace Hx002.Framework.Components
{
    public class HxRigidbody : HxComponent
    {
        public float AngularDrag;
        public Vector3 AngularVelocity;
        public Vector3 CenterOfMass;
        //public Vector3 CollisionDetectionMode;
        //public Vector3 Constraints;
        public bool DetectCollision;
        public float Drag;
        public bool FreezeRotation;
        public Vector3 InertiaTensor;
        public Quaternion InertiaTensorRotation;
        //public Quaternion Interpolation;
        public bool IsKinematic;
        public float Mass;
        public float MaxAngularVelocity;
        public float MaxDepenetrationVelocity;
        public Vector3 Position;
        public Quaternion Rotation;
        public float SleepThreshold;
        public int SolverIterations;
        public int SolverVelocityIterations;
        public bool UseGravity;
        public Vector3 Velocity;
        public Vector3 WorldCenterOfMass;
        
        public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0.0f, HxForceMode mode = HxForceMode.Force)
        {
            
        }

        public void AddForce(Vector3 force, HxForceMode mode = HxForceMode.Force)
        {
            
        }

        public void AddForceAtPosition(Vector3 force, Vector3 position, HxForceMode mode = HxForceMode.Force)
        {
            
        }
        
    }
}