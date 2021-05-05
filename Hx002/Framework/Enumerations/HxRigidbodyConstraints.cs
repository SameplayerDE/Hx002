namespace Hx002.Framework.Enumerations
{
    public enum HxRigidbodyConstraints
    {
        None, //No constraints.
        FreezePositionX, //Freeze motion along the X-axis.
        FreezePositionY, //Freeze motion along the Y-axis.
        FreezePositionZ, //Freeze motion along the Z-axis.
        FreezeRotationX, //Freeze rotation along the X-axis.
        FreezeRotationY, //Freeze rotation along the Y-axis.
        FreezeRotationZ, //Freeze rotation along the Z-axis.
        FreezePosition, //Freeze motion along all axes.
        FreezeRotation, //Freeze rotation along all axes.
        FreezeAll //Freeze rotation and motion along all axes.
    }
}