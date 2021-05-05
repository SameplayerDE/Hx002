namespace Hx002.Framework.Enumerations
{
    public enum HxForceMode
    {
        Force, //Add a continuous force to the rigidbody, using its mass.
        Acceleration, //Add a continuous acceleration to the rigidbody, ignoring its mass.
        Impulse, //Add an instant force impulse to the rigidbody, using its mass.
        VelocityChange //Add an instant velocity change to the rigidbody, ignoring its mass.
    }
}