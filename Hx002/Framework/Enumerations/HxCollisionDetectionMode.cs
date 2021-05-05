namespace Hx002.Framework.Enumerations
{
    public enum HxCollisionDetectionMode
    {
        Discrete, //Continuous collision detection is off for this Rigidbody.
        Continuous, //Continuous collision detection is on for colliding with static mesh geometry.
        ContinuousDynamic, //Continuous collision detection is on for colliding with static and dynamic geometry.
        ContinuousSpeculative //Speculative continuous collision detection is on for static and dynamic geometries
    }
}