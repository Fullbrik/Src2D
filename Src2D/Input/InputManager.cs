using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Src2D.Input
{
    public enum MouseButton
    {
        Left,
        Middle,
        Right,
        X1,
        X2
    }

    public static class InputManager
    {
        #region Keyboard
        private static void UpdateKeyboard()
        {
            keyboardState = Keyboard.GetState();
            keysPressed = keyboardState.GetPressedKeys()
                .Where(key => !keysPressed.Contains(key))
                .ToArray();
        }

        private static KeyboardState keyboardState;
        private static Keys[] keysPressed;

        /// <summary>
        /// Check if a key is currently down
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Key is currently down</returns>
        public static bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Check if this key has only been down this frame
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Key has only been down this frame</returns>
        public static bool WasKeyPressed(Keys key)
        {
            return keysPressed.Contains(key);
        }

        /// <summary>
        /// Check if a key is currently up
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Key is currently up</returns>
        public static bool IsKeyUp(Keys key)
        {
            return keyboardState.IsKeyUp(key);
        }
        #endregion

        #region Mouse
        private static void UpdateMouse()
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        private static MouseState mouseState;
        private static MouseState prevMouseState;

        /// <summary>
        /// The screen position of the mouse
        /// </summary>
        public static Point MouseScreenPosition
        {
            get => mouseState.Position;
            set => Mouse.SetPosition(value.X, value.Y);
        }

        /// <summary>
        /// The total amount the mouse has scrolled since the game started
        /// </summary>
        public static int MouseScrollAmount
        {
            get => mouseState.ScrollWheelValue;
        }

        /// <summary>
        /// The amount the mouse has scrolled this frame
        /// </summary>
        public static int MouseScrollDelta
        {
            get => mouseState.ScrollWheelValue - prevMouseState.ScrollWheelValue;
        }

        /// <summary>
        /// Check if a mouse button is down
        /// </summary>
        /// <param name="mouseButton">The mouse button to check</param>
        /// <returns>If the mouse button is down</returns>
        public static bool IsMouseButtonDown(MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return mouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return mouseState.MiddleButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return mouseState.RightButton == ButtonState.Pressed;
                case MouseButton.X1:
                    return mouseState.XButton1 == ButtonState.Pressed;
                case MouseButton.X2:
                    return mouseState.XButton2 == ButtonState.Pressed;
                default:
                    return false;
            }
        }

        public static bool IsMouseButtonPressed(MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return mouseState.LeftButton == ButtonState.Pressed
                        && prevMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Middle:
                    return mouseState.MiddleButton == ButtonState.Pressed
                        && prevMouseState.MiddleButton == ButtonState.Released;
                case MouseButton.Right:
                    return mouseState.RightButton == ButtonState.Pressed
                        && prevMouseState.RightButton == ButtonState.Released;
                case MouseButton.X1:
                    return mouseState.XButton1 == ButtonState.Pressed
                        && prevMouseState.XButton1 == ButtonState.Released;
                case MouseButton.X2:
                    return mouseState.XButton2 == ButtonState.Pressed
                        && prevMouseState.XButton2 == ButtonState.Released;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if a mouse button is up
        /// </summary>
        /// <param name="mouseButton">The mouse button to check</param>
        /// <returns>If the mouse button is up</returns>
        public static bool IsMouseButtonUp(MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return mouseState.LeftButton == ButtonState.Released;
                case MouseButton.Middle:
                    return mouseState.MiddleButton == ButtonState.Released;
                case MouseButton.Right:
                    return mouseState.RightButton == ButtonState.Released;
                case MouseButton.X1:
                    return mouseState.XButton1 == ButtonState.Released;
                case MouseButton.X2:
                    return mouseState.XButton2 == ButtonState.Released;
                default:
                    return false;
            }
        }
        #endregion

        internal static void Update()
        {
            UpdateKeyboard();
            UpdateMouse();
        }
    }
}
