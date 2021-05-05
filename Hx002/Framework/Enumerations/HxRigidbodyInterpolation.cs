namespace Hx002.Framework.Enumerations
{
    public enum HxRigidbodyInterpolation
    {
        None, //No Interpolation.
        Interpolate, //Interpolation will always lag a little bit behind but can be smoother than extrapolation.
        Extrapolate //Extrapolation will predict the position of the rigidbody based on the current velocity.
    }
}