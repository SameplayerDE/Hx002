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

        
        public static float GetAxis(string key)
        {
            float result = 0;
            if (HxCursor.LockMode == HxCursorLockMode.Locked)
            {
                SetCursorPosition(Hx.GraphicsDevice.Viewport.Bounds.Center);
                if (key == "Mouse X")
                {
                    result = CurrentMouseState.X - Hx.GraphicsDevice.Viewport.Bounds.Center.X;
                }
                else if (key == "Mouse Y")
                {
                    result = CurrentMouseState.Y - Hx.GraphicsDevice.Viewport.Bounds.Center.Y;
                }
            }
            else
            {
                if (key == "Mouse X")
                {
                    result = CurrentMouseState.X - PreviouseMouseState.X;
                }
                else if (key == "Mouse Y")
                {
                    result = CurrentMouseState.Y - PreviouseMouseState.Y;
                }
            }

            if (key == "Horizontal")
            {
                bool left, right;
                left = CurrentKeyboardState.IsKeyDown(Keys.A);
                right = CurrentKeyboardState.IsKeyDown(Keys.D);
                if (right)
                {
                    result += 1;
                }
                if (left)
                {
                    result -= 1;
                }
            }
            else if (key == "Vertical")
            {

                bool up, down;
                up = CurrentKeyboardState.IsKeyDown(Keys.W);
                down = CurrentKeyboardState.IsKeyDown(Keys.S);
                if (up)
                {
                    result += 1;
                }
                if (down)
                {
                    result -= 1;
                }
            }
            return result;
        }
        
        public static void Update(GameTime gameTime)
        {
            RefreshStates();
        }

        private static void RefreshStates()
        {
            PreviouseKeyboardState = CurrentKeyboardState;
            PreviouseMouseState = CurrentMouseState;
            //PreviouseGamepadStates = CurrentGamepadStates;
            
            for (int i = 0; i < 4; i++)
            {
                PreviouseGamepadStates[i] = CurrentGamepadStates[i];
            }

            CurrentKeyboardState = Keyboard.GetState();
            CurrentMouseState = Mouse.GetState();

            for (int i = 0; i < 4; i++)
            {
                CurrentGamepadStates[i] = GamePad.GetState(i);
            }
        }

        public static void SetCursorPosition(Point position)
        {
            Mouse.SetPosition(position.X, position.Y);
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
        
        #region Gamepad

        public static bool IsButtonDown(PlayerIndex index, Buttons button)
        {
            return CurrentGamepadStates[(int) index].IsButtonDown(button);
        }
        public static bool IsButtonUp(PlayerIndex index, Buttons button)
        {
            return CurrentGamepadStates[(int) index].IsButtonUp(button);
        }
        
        public static bool WasButtonDown(PlayerIndex index, Buttons button)
        {
            return PreviouseGamepadStates[(int) index].IsButtonDown(button);
        }
        public static bool WasButtonUp(PlayerIndex index, Buttons button)
        {
            return PreviouseGamepadStates[(int) index].IsButtonUp(button);
        }
        
        public static bool IsButtonPressed(PlayerIndex index, Buttons button)
        {
            return IsButtonDown(index, button) && WasButtonUp(index, button);
        }
        public static bool IsButtonReleased(PlayerIndex index, Buttons button)
        {
            return IsButtonUp(index, button) && WasButtonDown(index, button);
        }
        
        public static bool IsGamePadConnected(PlayerIndex index)
        {
            return CurrentGamepadStates[(int) index].IsConnected;
        }
        #endregion
        
    }
}