namespace Hx002.Framework
{

    public enum HxCursorLockMode
    {
        None, //Cursor behavior is unmodified.
        Locked, //Lock cursor to the center of the game window.
        Confined //Confine cursor to the game window.
    }
    
    public static class HxCursor
    {
        public static bool Visible = true;
        public static HxCursorLockMode LockMode = HxCursorLockMode.None;
    }
}