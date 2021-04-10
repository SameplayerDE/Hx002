using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hx002.Framework
{
    public static class HxInput
    {

        public static KeyboardState CurrentKeyboardState;
        public static KeyboardState PreviouseKeyboardState;

        public static MouseState CurrentMouseState;
        public static MouseState PreviouseMouseState;

        public static GamePadState[] CurrentGamepadStates = new GamePadState[4] { GamePad.GetState(0), GamePad.GetState(1), GamePad.GetState(2), GamePad.GetState(3) };
        public static GamePadState[] PreviouseGamepadStates = new GamePadState[4];

        public static void Update(GameTime gameTime)
        {
            RefreshStates();
        }

        private static void RefreshStates()
        {
            PreviouseKeyboardState = CurrentKeyboardState;
            PreviouseMouseState = CurrentMouseState;
            PreviouseGamepadStates = CurrentGamepadStates;

            CurrentKeyboardState = Keyboard.GetState();
            CurrentMouseState = Mouse.GetState();

            for (int i = 0; i < 4; i++)
            {
                CurrentGamepadStates[i] = GamePad.GetState(i);
            }
        }
        
        #region Keyboard
        public static bool IsKeyDown(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }
        public static bool IsKeyUp(Keys key)
        {
            return CurrentKeyboardState.IsKeyUp(key);
        }

        public static bool WasKeyDown(Keys key)
        {
            return PreviouseKeyboardState.IsKeyDown(key);
        }
        public static bool WasKeyUp(Keys key)
        {
            return PreviouseKeyboardState.IsKeyUp(key);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return IsKeyDown(key) && WasKeyUp(key);
        }
        public static bool IsKeyReleased(Keys key) 
        {
            return IsKeyUp(key) && WasKeyDown(key);
        }
        #endregion
        
    }
}