/* 
 Windows Virtual Key Wrapper ver 1.0.0
 Written by Byulbram 2016 (byulbram@ck.ac.kr)
 Byulbram Studio / ChungKang College of Cultural Industry
 
 This Code was written for bypass Unity KeyCode input problem in non-english IME keyboard

 How To Use:
    Just insert "using WindowsInput" to your code 
    and use WinInput.GetKey() instead of Input.GetKey()
    This will work on Windows PC Platform 
*/
using UnityEngine;
using System.Collections;
#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
using System.Runtime.InteropServices;
#endif

namespace WindowsInput
{
    public class WinInput
    {
#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]

        protected static extern short GetAsyncKeyState(int keyCode);        
        private static bool[] m_PrevKeyStateDown = new bool[(int)KeyCode.Joystick8Button19];
        private static bool[] m_PrevKeyStateUp = new bool[(int)KeyCode.Joystick8Button19];

        // Mapper for Unity KeyCode to Virtual KeyCode with full key set
        private static int KeyCodeToVkeyFullSet(KeyCode key) 
        {
            int VK = 0;
            switch (key)
            {
                case KeyCode.Backspace: VK = 0x08; break;
                case KeyCode.Tab: VK = 0x09; break;
                case KeyCode.Clear: VK = 0x0C; break;
                case KeyCode.Return: VK = 0x0D; break;
                case KeyCode.Pause: VK = 0x13; break;
                case KeyCode.Escape: VK = 0x1B; break;
                case KeyCode.Space: VK = 0x20; break;
                case KeyCode.Exclaim: VK = 0x31; break;
                case KeyCode.DoubleQuote: VK = 0xDE; break;
                case KeyCode.Hash: VK = 0x33; break;
                case KeyCode.Dollar: VK = 0x34; break;
                case KeyCode.Ampersand: VK = 0x37; break;
                case KeyCode.Quote: VK = 0xDE; break;
                case KeyCode.LeftParen: VK = 0x39; break;
                case KeyCode.RightParen: VK = 0x30; break;
                case KeyCode.Asterisk: VK = 0x13; break;
                case KeyCode.Equals: 
                case KeyCode.Plus: VK = 0xBB; break;
                case KeyCode.Less: 
                case KeyCode.Comma: VK = 0xBC; break;
                case KeyCode.Underscore: 
                case KeyCode.Minus: VK = 0xBD; break;
                case KeyCode.Greater: 
                case KeyCode.Period: VK = 0xBE; break;
                case KeyCode.Question: 
                case KeyCode.Slash: VK = 0xBF; break;

                case KeyCode.Alpha0:
                case KeyCode.Alpha1:
                case KeyCode.Alpha2:
                case KeyCode.Alpha3:
                case KeyCode.Alpha4:
                case KeyCode.Alpha5:
                case KeyCode.Alpha6:
                case KeyCode.Alpha7:
                case KeyCode.Alpha8:
                case KeyCode.Alpha9:
                    VK = 0x30 + ((int)key - (int)KeyCode.Alpha0); break;
                case KeyCode.Colon: 
                case KeyCode.Semicolon: VK = 0xBA; break;

                case KeyCode.At: VK = 0x32; break;
                case KeyCode.LeftBracket: VK = 0xDB; break;
                case KeyCode.Backslash: VK = 0xDC; break;
                case KeyCode.RightBracket: VK = 0xDD; break;
                case KeyCode.Caret: VK = 0x36; break;                
                case KeyCode.BackQuote: VK = 0xC0; break;

                case KeyCode.A:
                case KeyCode.B:
                case KeyCode.C:
                case KeyCode.D:
                case KeyCode.E:
                case KeyCode.F:
                case KeyCode.G:
                case KeyCode.H:
                case KeyCode.I:
                case KeyCode.J:
                case KeyCode.K:
                case KeyCode.L:
                case KeyCode.M:
                case KeyCode.N:
                case KeyCode.O:
                case KeyCode.P:
                case KeyCode.Q:
                case KeyCode.R:
                case KeyCode.S:
                case KeyCode.T:
                case KeyCode.U:
                case KeyCode.V:
                case KeyCode.W:
                case KeyCode.X:
                case KeyCode.Y:
                case KeyCode.Z:
                    VK = 0x41 + ((int)key - (int)KeyCode.A); break;

                case KeyCode.Delete: VK = 0x2E; break;
                case KeyCode.Keypad0:
                case KeyCode.Keypad1:
                case KeyCode.Keypad2:
                case KeyCode.Keypad3:
                case KeyCode.Keypad4:
                case KeyCode.Keypad5:
                case KeyCode.Keypad6:
                case KeyCode.Keypad7:
                case KeyCode.Keypad8:
                case KeyCode.Keypad9:
                    VK = 0x60 + ((int)key - (int)KeyCode.Keypad0); break;

                case KeyCode.KeypadPeriod: VK = 0x6E; break;
                case KeyCode.KeypadDivide: VK = 0x6F; break;
                case KeyCode.KeypadMultiply: VK = 0x6A; break;
                case KeyCode.KeypadMinus: VK = 0x6D; break;
                case KeyCode.KeypadPlus: VK = 0x6B; break;                
                case KeyCode.KeypadEnter: VK = 0x6C; break;
                //case KeyCode.KeypadEquals: VK = 0x00; break;
                case KeyCode.UpArrow: VK = 0x26; break;
                case KeyCode.DownArrow: VK = 0x28; break;
                case KeyCode.RightArrow: VK = 0x27; break;
                case KeyCode.LeftArrow: VK = 0x25; break;
                case KeyCode.Insert: VK = 0x2D; break;                
                case KeyCode.Home: VK = 0x24; break;
                case KeyCode.End: VK = 0x23; break;
                case KeyCode.PageUp: VK = 0x21; break;
                case KeyCode.PageDown: VK = 0x22; break;

                case KeyCode.F1:
                case KeyCode.F2:
                case KeyCode.F3:
                case KeyCode.F4:
                case KeyCode.F5:
                case KeyCode.F6:
                case KeyCode.F7:
                case KeyCode.F8:
                case KeyCode.F9:
                case KeyCode.F10:
                case KeyCode.F11:
                case KeyCode.F12:
                case KeyCode.F13:
                case KeyCode.F14:
                case KeyCode.F15:
                    VK = 0x70 + ((int)key - (int)KeyCode.F1); break;

                case KeyCode.Numlock: VK = 0x90; break;
                case KeyCode.CapsLock: VK = 0x14; break;
                case KeyCode.ScrollLock: VK = 0x91; break;
                case KeyCode.RightShift: VK = 0xA1; break;
                case KeyCode.LeftShift: VK = 0xA0; break;
                case KeyCode.RightControl: VK = 0xA3; break;
                case KeyCode.LeftControl: VK = 0xA2; break;
                case KeyCode.RightAlt: VK = 0xA5; break;
                case KeyCode.LeftAlt: VK = 0xA4; break;
                //case KeyCode.RightCommand: VK = 0x22; break;
                //case KeyCode.RightApple: VK = 0x22; break;
                //case KeyCode.LeftCommand: VK = 0x22; break;
                //case KeyCode.LeftApple: VK = 0x22; break;
                //case KeyCode.LeftWindows: VK = 0x22; break;
                //case KeyCode.RightWindows: VK = 0x22; break;
                case KeyCode.Help: VK = 0xE3; break;
                case KeyCode.Print: VK = 0x2A; break;
                case KeyCode.SysReq: VK = 0x2C; break;
                case KeyCode.Break: VK = 0x03; break;
            }
            return VK;
        }

        // Simplified Mapper for Unity KeyCode to Virtual KeyCode with Alphabet key set
        private static int KeyCodeToVkey(KeyCode key)
        {
            int VK = 0;
            switch (key)
            {
                case KeyCode.A:
                case KeyCode.B:
                case KeyCode.C:
                case KeyCode.D:
                case KeyCode.E:
                case KeyCode.F:
                case KeyCode.G:
                case KeyCode.H:
                case KeyCode.I:
                case KeyCode.J:
                case KeyCode.K:
                case KeyCode.L:
                case KeyCode.M:
                case KeyCode.N:
                case KeyCode.O:
                case KeyCode.P:
                case KeyCode.Q:
                case KeyCode.R:
                case KeyCode.S:
                case KeyCode.T:
                case KeyCode.U:
                case KeyCode.V:
                case KeyCode.W:
                case KeyCode.X:
                case KeyCode.Y:
                case KeyCode.Z:
                    VK = 0x41 + ((int)key - (int)KeyCode.A); break;
            }
            return VK;
        }
#endif

        // GetKey with GetAsyncKeyState for IME Alphabets
        public static bool GetKey(KeyCode key)
        {
#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
            int VK = KeyCodeToVkey(key);

            //Changed 2021.01.08: Thanks to 우유들컴(4joseph)
            var ret = GetAsyncKeyState(VK);
            return ret != 0 && ret != 1;
            
#else
            return Input.GetKey(key);
#endif            

        }

        // GetKeyDown with GetAsyncKeyState for IME Alphabets
        // Changed 2021.01.08: Thanks to Flashscope
        public static bool GetKeyDown(KeyCode key)
        {
#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
            bool result = false;
            int keyState = GetAsyncKeyState(KeyCodeToVkeyFullSet(key));
            if (keyState == 0 || keyState == 1)
            {
                m_PrevKeyStateDown[(int)key] = false;                
            }
            else 
            {
                if (m_PrevKeyStateDown[(int)key] == false)
                    result = true;
                m_PrevKeyStateDown[(int)key] = true;
            }
            return result;
#else
return Input.GetKeyDown(key);
#endif
        }

        public static bool GetKeyUp(KeyCode key)
        {
#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
            bool result = false;
            int keyState = GetAsyncKeyState(KeyCodeToVkeyFullSet(key));

            if (keyState != 0 && keyState != 1)
            {
                m_PrevKeyStateUp[(int)key] = true;
            }
            else
            {
                if (m_PrevKeyStateUp[(int)key] == true)
                    result = true;
                m_PrevKeyStateUp[(int)key] = false;
            }
            return result;
#else
return Input.GetKeyUp(key);
#endif
        }


        // GetKey with GetAsyncKeyState for full keycode
        public static bool GetKeyFullCover(KeyCode key)
        {
#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
            int VK = KeyCodeToVkeyFullSet(key);
            if (VK != 0)
                return (GetAsyncKeyState(VK) != 0);
            else
                return Input.GetKey(key);
#else
            return Input.GetKey(key);
#endif
        }

#if (UNITY_STANDALONE_WIN && !UNITY_EDITOR_OSX)
        // Key Check with Virtual Keycode
        public static bool GetKeyVK(int VKey)
        {
            return (GetAsyncKeyState(VKey) != 0);
        }
#endif


    }
}
