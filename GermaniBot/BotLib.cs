


using System;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO;

namespace BOTLIB
{
    public class BotUtilityNative
    {
        #region DLL IMPORTS

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
           public int Right;
           public int Left;
           public int Top;
           public int Bottom;
        }
        
        [DllImport("User32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);


        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs,[MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,int cbSize);

        
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            internal uint type;
            internal InputUnion U;
            internal static int Size
            {
                get { return Marshal.SizeOf(typeof(INPUT)); }
            }
        }

      
        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion
        {
            [FieldOffset(0)]
            internal MOUSEINPUT mi;
            [FieldOffset(0)]
            internal KEYBDINPUT ki;
            [FieldOffset(0)]
            internal HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            internal int dx;
            internal int dy;
            internal MouseEventDataXButtons mouseData;
            internal MOUSEEVENTF dwFlags;
            internal uint time;
            internal UIntPtr dwExtraInfo;
        }

        [Flags]
        internal enum MouseEventDataXButtons : uint
        {
            Nothing = 0x00000000,
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }

        [Flags]
        internal enum MOUSEEVENTF : uint
        {
            ABSOLUTE = 0x8000,
            HWHEEL = 0x01000,
            MOVE = 0x0001,
            MOVE_NOCOALESCE = 0x2000,
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            VIRTUALDESK = 0x4000,
            WHEEL = 0x0800,
            XDOWN = 0x0080,
            XUP = 0x0100
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            internal VirtualKeyShort wVk;
            internal ScanCodeShort wScan;
            internal KEYEVENTF dwFlags;
            internal int time;
            internal UIntPtr dwExtraInfo;
        }

        [Flags]
        internal enum KEYEVENTF : uint
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            SCANCODE = 0x0008,
            UNICODE = 0x0004
        }

        internal enum VirtualKeyShort : short
        {
            ///<summary>
            ///Left mouse button
            ///</summary>
            LBUTTON = 0x01,
            ///<summary>
            ///Right mouse button
            ///</summary>
            RBUTTON = 0x02,
            ///<summary>
            ///Control-break processing
            ///</summary>
            CANCEL = 0x03,
            ///<summary>
            ///Middle mouse button (three-button mouse)
            ///</summary>
            MBUTTON = 0x04,
            ///<summary>
            ///Windows 2000/XP: X1 mouse button
            ///</summary>
            XBUTTON1 = 0x05,
            ///<summary>
            ///Windows 2000/XP: X2 mouse button
            ///</summary>
            XBUTTON2 = 0x06,
            ///<summary>
            ///BACKSPACE key
            ///</summary>
            BACK = 0x08,
            ///<summary>
            ///TAB key
            ///</summary>
            TAB = 0x09,
            ///<summary>
            ///CLEAR key
            ///</summary>
            CLEAR = 0x0C,
            ///<summary>
            ///ENTER key
            ///</summary>
            RETURN = 0x0D,
            ///<summary>
            ///SHIFT key
            ///</summary>
            SHIFT = 0x10,
            ///<summary>
            ///CTRL key
            ///</summary>
            CONTROL = 0x11,
            ///<summary>
            ///ALT key
            ///</summary>
            MENU = 0x12,
            ///<summary>
            ///PAUSE key
            ///</summary>
            PAUSE = 0x13,
            ///<summary>
            ///CAPS LOCK key
            ///</summary>
            CAPITAL = 0x14,
            ///<summary>
            ///Input Method Editor (IME) Kana mode
            ///</summary>
            KANA = 0x15,
            ///<summary>
            ///IME Hangul mode
            ///</summary>
            HANGUL = 0x15,
            ///<summary>
            ///IME Junja mode
            ///</summary>
            JUNJA = 0x17,
            ///<summary>
            ///IME final mode
            ///</summary>
            FINAL = 0x18,
            ///<summary>
            ///IME Hanja mode
            ///</summary>
            HANJA = 0x19,
            ///<summary>
            ///IME Kanji mode
            ///</summary>
            KANJI = 0x19,
            ///<summary>
            ///ESC key
            ///</summary>
            ESCAPE = 0x1B,
            ///<summary>
            ///IME convert
            ///</summary>
            CONVERT = 0x1C,
            ///<summary>
            ///IME nonconvert
            ///</summary>
            NONCONVERT = 0x1D,
            ///<summary>
            ///IME accept
            ///</summary>
            ACCEPT = 0x1E,
            ///<summary>
            ///IME mode change request
            ///</summary>
            MODECHANGE = 0x1F,
            ///<summary>
            ///SPACEBAR
            ///</summary>
            SPACE = 0x20,
            ///<summary>
            ///PAGE UP key
            ///</summary>
            PRIOR = 0x21,
            ///<summary>
            ///PAGE DOWN key
            ///</summary>
            NEXT = 0x22,
            ///<summary>
            ///END key
            ///</summary>
            END = 0x23,
            ///<summary>
            ///HOME key
            ///</summary>
            HOME = 0x24,
            ///<summary>
            ///LEFT ARROW key
            ///</summary>
            LEFT = 0x25,
            ///<summary>
            ///UP ARROW key
            ///</summary>
            UP = 0x26,
            ///<summary>
            ///RIGHT ARROW key
            ///</summary>
            RIGHT = 0x27,
            ///<summary>
            ///DOWN ARROW key
            ///</summary>
            DOWN = 0x28,
            ///<summary>
            ///SELECT key
            ///</summary>
            SELECT = 0x29,
            ///<summary>
            ///PRINT key
            ///</summary>
            PRINT = 0x2A,
            ///<summary>
            ///EXECUTE key
            ///</summary>
            EXECUTE = 0x2B,
            ///<summary>
            ///PRINT SCREEN key
            ///</summary>
            SNAPSHOT = 0x2C,
            ///<summary>
            ///INS key
            ///</summary>
            INSERT = 0x2D,
            ///<summary>
            ///DEL key
            ///</summary>
            DELETE = 0x2E,
            ///<summary>
            ///HELP key
            ///</summary>
            HELP = 0x2F,
            ///<summary>
            ///0 key
            ///</summary>
            KEY_0 = 0x30,
            ///<summary>
            ///1 key
            ///</summary>
            KEY_1 = 0x31,
            ///<summary>
            ///2 key
            ///</summary>
            KEY_2 = 0x32,
            ///<summary>
            ///3 key
            ///</summary>
            KEY_3 = 0x33,
            ///<summary>
            ///4 key
            ///</summary>
            KEY_4 = 0x34,
            ///<summary>
            ///5 key
            ///</summary>
            KEY_5 = 0x35,
            ///<summary>
            ///6 key
            ///</summary>
            KEY_6 = 0x36,
            ///<summary>
            ///7 key
            ///</summary>
            KEY_7 = 0x37,
            ///<summary>
            ///8 key
            ///</summary>
            KEY_8 = 0x38,
            ///<summary>
            ///9 key
            ///</summary>
            KEY_9 = 0x39,
            ///<summary>
            ///A key
            ///</summary>
            KEY_A = 0x41,
            ///<summary>
            ///B key
            ///</summary>
            KEY_B = 0x42,
            ///<summary>
            ///C key
            ///</summary>
            KEY_C = 0x43,
            ///<summary>
            ///D key
            ///</summary>
            KEY_D = 0x44,
            ///<summary>
            ///E key
            ///</summary>
            KEY_E = 0x45,
            ///<summary>
            ///F key
            ///</summary>
            KEY_F = 0x46,
            ///<summary>
            ///G key
            ///</summary>
            KEY_G = 0x47,
            ///<summary>
            ///H key
            ///</summary>
            KEY_H = 0x48,
            ///<summary>
            ///I key
            ///</summary>
            KEY_I = 0x49,
            ///<summary>
            ///J key
            ///</summary>
            KEY_J = 0x4A,
            ///<summary>
            ///K key
            ///</summary>
            KEY_K = 0x4B,
            ///<summary>
            ///L key
            ///</summary>
            KEY_L = 0x4C,
            ///<summary>
            ///M key
            ///</summary>
            KEY_M = 0x4D,
            ///<summary>
            ///N key
            ///</summary>
            KEY_N = 0x4E,
            ///<summary>
            ///O key
            ///</summary>
            KEY_O = 0x4F,
            ///<summary>
            ///P key
            ///</summary>
            KEY_P = 0x50,
            ///<summary>
            ///Q key
            ///</summary>
            KEY_Q = 0x51,
            ///<summary>
            ///R key
            ///</summary>
            KEY_R = 0x52,
            ///<summary>
            ///S key
            ///</summary>
            KEY_S = 0x53,
            ///<summary>
            ///T key
            ///</summary>
            KEY_T = 0x54,
            ///<summary>
            ///U key
            ///</summary>
            KEY_U = 0x55,
            ///<summary>
            ///V key
            ///</summary>
            KEY_V = 0x56,
            ///<summary>
            ///W key
            ///</summary>
            KEY_W = 0x57,
            ///<summary>
            ///X key
            ///</summary>
            KEY_X = 0x58,
            ///<summary>
            ///Y key
            ///</summary>
            KEY_Y = 0x59,
            ///<summary>
            ///Z key
            ///</summary>
            KEY_Z = 0x5A,
            ///<summary>
            ///Left Windows key (Microsoft Natural keyboard) 
            ///</summary>
            LWIN = 0x5B,
            ///<summary>
            ///Right Windows key (Natural keyboard)
            ///</summary>
            RWIN = 0x5C,
            ///<summary>
            ///Applications key (Natural keyboard)
            ///</summary>
            APPS = 0x5D,
            ///<summary>
            ///Computer Sleep key
            ///</summary>
            SLEEP = 0x5F,
            ///<summary>
            ///Numeric keypad 0 key
            ///</summary>
            NUMPAD0 = 0x60,
            ///<summary>
            ///Numeric keypad 1 key
            ///</summary>
            NUMPAD1 = 0x61,
            ///<summary>
            ///Numeric keypad 2 key
            ///</summary>
            NUMPAD2 = 0x62,
            ///<summary>
            ///Numeric keypad 3 key
            ///</summary>
            NUMPAD3 = 0x63,
            ///<summary>
            ///Numeric keypad 4 key
            ///</summary>
            NUMPAD4 = 0x64,
            ///<summary>
            ///Numeric keypad 5 key
            ///</summary>
            NUMPAD5 = 0x65,
            ///<summary>
            ///Numeric keypad 6 key
            ///</summary>
            NUMPAD6 = 0x66,
            ///<summary>
            ///Numeric keypad 7 key
            ///</summary>
            NUMPAD7 = 0x67,
            ///<summary>
            ///Numeric keypad 8 key
            ///</summary>
            NUMPAD8 = 0x68,
            ///<summary>
            ///Numeric keypad 9 key
            ///</summary>
            NUMPAD9 = 0x69,
            ///<summary>
            ///Multiply key
            ///</summary>
            MULTIPLY = 0x6A,
            ///<summary>
            ///Add key
            ///</summary>
            ADD = 0x6B,
            ///<summary>
            ///Separator key
            ///</summary>
            SEPARATOR = 0x6C,
            ///<summary>
            ///Subtract key
            ///</summary>
            SUBTRACT = 0x6D,
            ///<summary>
            ///Decimal key
            ///</summary>
            DECIMAL = 0x6E,
            ///<summary>
            ///Divide key
            ///</summary>
            DIVIDE = 0x6F,
            ///<summary>
            ///F1 key
            ///</summary>
            F1 = 0x70,
            ///<summary>
            ///F2 key
            ///</summary>
            F2 = 0x71,
            ///<summary>
            ///F3 key
            ///</summary>
            F3 = 0x72,
            ///<summary>
            ///F4 key
            ///</summary>
            F4 = 0x73,
            ///<summary>
            ///F5 key
            ///</summary>
            F5 = 0x74,
            ///<summary>
            ///F6 key
            ///</summary>
            F6 = 0x75,
            ///<summary>
            ///F7 key
            ///</summary>
            F7 = 0x76,
            ///<summary>
            ///F8 key
            ///</summary>
            F8 = 0x77,
            ///<summary>
            ///F9 key
            ///</summary>
            F9 = 0x78,
            ///<summary>
            ///F10 key
            ///</summary>
            F10 = 0x79,
            ///<summary>
            ///F11 key
            ///</summary>
            F11 = 0x7A,
            ///<summary>
            ///F12 key
            ///</summary>
            F12 = 0x7B,
            ///<summary>
            ///F13 key
            ///</summary>
            F13 = 0x7C,
            ///<summary>
            ///F14 key
            ///</summary>
            F14 = 0x7D,
            ///<summary>
            ///F15 key
            ///</summary>
            F15 = 0x7E,
            ///<summary>
            ///F16 key
            ///</summary>
            F16 = 0x7F,
            ///<summary>
            ///F17 key  
            ///</summary>
            F17 = 0x80,
            ///<summary>
            ///F18 key  
            ///</summary>
            F18 = 0x81,
            ///<summary>
            ///F19 key  
            ///</summary>
            F19 = 0x82,
            ///<summary>
            ///F20 key  
            ///</summary>
            F20 = 0x83,
            ///<summary>
            ///F21 key  
            ///</summary>
            F21 = 0x84,
            ///<summary>
            ///F22 key, (PPC only) Key used to lock device.
            ///</summary>
            F22 = 0x85,
            ///<summary>
            ///F23 key  
            ///</summary>
            F23 = 0x86,
            ///<summary>
            ///F24 key  
            ///</summary>
            F24 = 0x87,
            ///<summary>
            ///NUM LOCK key
            ///</summary>
            NUMLOCK = 0x90,
            ///<summary>
            ///SCROLL LOCK key
            ///</summary>
            SCROLL = 0x91,
            ///<summary>
            ///Left SHIFT key
            ///</summary>
            LSHIFT = 0xA0,
            ///<summary>
            ///Right SHIFT key
            ///</summary>
            RSHIFT = 0xA1,
            ///<summary>
            ///Left CONTROL key
            ///</summary>
            LCONTROL = 0xA2,
            ///<summary>
            ///Right CONTROL key
            ///</summary>
            RCONTROL = 0xA3,
            ///<summary>
            ///Left MENU key
            ///</summary>
            LMENU = 0xA4,
            ///<summary>
            ///Right MENU key
            ///</summary>
            RMENU = 0xA5,
            ///<summary>
            ///Windows 2000/XP: Browser Back key
            ///</summary>
            BROWSER_BACK = 0xA6,
            ///<summary>
            ///Windows 2000/XP: Browser Forward key
            ///</summary>
            BROWSER_FORWARD = 0xA7,
            ///<summary>
            ///Windows 2000/XP: Browser Refresh key
            ///</summary>
            BROWSER_REFRESH = 0xA8,
            ///<summary>
            ///Windows 2000/XP: Browser Stop key
            ///</summary>
            BROWSER_STOP = 0xA9,
            ///<summary>
            ///Windows 2000/XP: Browser Search key 
            ///</summary>
            BROWSER_SEARCH = 0xAA,
            ///<summary>
            ///Windows 2000/XP: Browser Favorites key
            ///</summary>
            BROWSER_FAVORITES = 0xAB,
            ///<summary>
            ///Windows 2000/XP: Browser Start and Home key
            ///</summary>
            BROWSER_HOME = 0xAC,
            ///<summary>
            ///Windows 2000/XP: Volume Mute key
            ///</summary>
            VOLUME_MUTE = 0xAD,
            ///<summary>
            ///Windows 2000/XP: Volume Down key
            ///</summary>
            VOLUME_DOWN = 0xAE,
            ///<summary>
            ///Windows 2000/XP: Volume Up key
            ///</summary>
            VOLUME_UP = 0xAF,
            ///<summary>
            ///Windows 2000/XP: Next Track key
            ///</summary>
            MEDIA_NEXT_TRACK = 0xB0,
            ///<summary>
            ///Windows 2000/XP: Previous Track key
            ///</summary>
            MEDIA_PREV_TRACK = 0xB1,
            ///<summary>
            ///Windows 2000/XP: Stop Media key
            ///</summary>
            MEDIA_STOP = 0xB2,
            ///<summary>
            ///Windows 2000/XP: Play/Pause Media key
            ///</summary>
            MEDIA_PLAY_PAUSE = 0xB3,
            ///<summary>
            ///Windows 2000/XP: Start Mail key
            ///</summary>
            LAUNCH_MAIL = 0xB4,
            ///<summary>
            ///Windows 2000/XP: Select Media key
            ///</summary>
            LAUNCH_MEDIA_SELECT = 0xB5,
            ///<summary>
            ///Windows 2000/XP: Start Application 1 key
            ///</summary>
            LAUNCH_APP1 = 0xB6,
            ///<summary>
            ///Windows 2000/XP: Start Application 2 key
            ///</summary>
            LAUNCH_APP2 = 0xB7,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_1 = 0xBA,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '+' key
            ///</summary>
            OEM_PLUS = 0xBB,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the ',' key
            ///</summary>
            OEM_COMMA = 0xBC,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '-' key
            ///</summary>
            OEM_MINUS = 0xBD,
            ///<summary>
            ///Windows 2000/XP: For any country/region, the '.' key
            ///</summary>
            OEM_PERIOD = 0xBE,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_2 = 0xBF,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_3 = 0xC0,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_4 = 0xDB,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_5 = 0xDC,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_6 = 0xDD,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard. 
            ///</summary>
            OEM_7 = 0xDE,
            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_8 = 0xDF,
            ///<summary>
            ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
            ///</summary>
            OEM_102 = 0xE2,
            ///<summary>
            ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
            ///</summary>
            PROCESSKEY = 0xE5,
            ///<summary>
            ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
            ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
            ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
            ///</summary>
            PACKET = 0xE7,
            ///<summary>
            ///Attn key
            ///</summary>
            ATTN = 0xF6,
            ///<summary>
            ///CrSel key
            ///</summary>
            CRSEL = 0xF7,
            ///<summary>
            ///ExSel key
            ///</summary>
            EXSEL = 0xF8,
            ///<summary>
            ///Erase EOF key
            ///</summary>
            EREOF = 0xF9,
            ///<summary>
            ///Play key
            ///</summary>
            PLAY = 0xFA,
            ///<summary>
            ///Zoom key
            ///</summary>
            ZOOM = 0xFB,
            ///<summary>
            ///Reserved 
            ///</summary>
            NONAME = 0xFC,
            ///<summary>
            ///PA1 key
            ///</summary>
            PA1 = 0xFD,
            ///<summary>
            ///Clear key
            ///</summary>
            OEM_CLEAR = 0xFE
        }
        public  enum ScanCodeShort : short
        {
            LBUTTON = 0,
            RBUTTON = 0,
            CANCEL = 70,
            MBUTTON = 0,
            XBUTTON1 = 0,
            XBUTTON2 = 0,
            BACK = 14,
            TAB = 15,
            CLEAR = 76,
            RETURN = 28,
            SHIFT = 42,
            CONTROL = 29,
            MENU = 56,
            PAUSE = 0,
            CAPITAL = 58,
            KANA = 0,
            HANGUL = 0,
            JUNJA = 0,
            FINAL = 0,
            HANJA = 0,
            KANJI = 0,
            ESCAPE = 1,
            CONVERT = 0,
            NONCONVERT = 0,
            ACCEPT = 0,
            MODECHANGE = 0,
            SPACE = 57,
            PRIOR = 73,
            NEXT = 81,
            END = 79,
            HOME = 71,
            LEFT = 75,
            UP = 72,
            RIGHT = 77,
            DOWN = 80,
            SELECT = 0,
            PRINT = 0,
            EXECUTE = 0,
            SNAPSHOT = 84,
            INSERT = 82,
            DELETE = 83,
            HELP = 99,
            KEY_0 = 11,
            KEY_1 = 2,
            KEY_2 = 3,
            KEY_3 = 4,
            KEY_4 = 5,
            KEY_5 = 6,
            KEY_6 = 7,
            KEY_7 = 8,
            KEY_8 = 9,
            KEY_9 = 10,
            KEY_A = 30,
            KEY_B = 48,
            KEY_C = 46,
            KEY_D = 32,
            KEY_E = 18,
            KEY_F = 33,
            KEY_G = 34,
            KEY_H = 35,
            KEY_I = 23,
            KEY_J = 36,
            KEY_K = 37,
            KEY_L = 38,
            KEY_M = 50,
            KEY_N = 49,
            KEY_O = 24,
            KEY_P = 25,
            KEY_Q = 16,
            KEY_R = 19,
            KEY_S = 31,
            KEY_T = 20,
            KEY_U = 22,
            KEY_V = 47,
            KEY_W = 17,
            KEY_X = 45,
            KEY_Y = 21,
            KEY_Z = 44,
            LWIN = 91,
            RWIN = 92,
            APPS = 93,
            SLEEP = 95,
            NUMPAD0 = 82,
            NUMPAD1 = 79,
            NUMPAD2 = 80,
            NUMPAD3 = 81,
            NUMPAD4 = 75,
            NUMPAD5 = 76,
            NUMPAD6 = 77,
            NUMPAD7 = 71,
            NUMPAD8 = 72,
            NUMPAD9 = 73,
            MULTIPLY = 55,
            ADD = 78,
            SEPARATOR = 0,
            SUBTRACT = 74,
            DECIMAL = 83,
            DIVIDE = 53,
            F1 = 59,
            F2 = 60,
            F3 = 61,
            F4 = 62,
            F5 = 63,
            F6 = 64,
            F7 = 65,
            F8 = 66,
            F9 = 67,
            F10 = 68,
            F11 = 87,
            F12 = 88,
            F13 = 100,
            F14 = 101,
            F15 = 102,
            F16 = 103,
            F17 = 104,
            F18 = 105,
            F19 = 106,
            F20 = 107,
            F21 = 108,
            F22 = 109,
            F23 = 110,
            F24 = 118,
            NUMLOCK = 69,
            SCROLL = 70,
            LSHIFT = 42,
            RSHIFT = 54,
            LCONTROL = 29,
            RCONTROL = 29,
            LMENU = 56,
            RMENU = 56,
            BROWSER_BACK = 106,
            BROWSER_FORWARD = 105,
            BROWSER_REFRESH = 103,
            BROWSER_STOP = 104,
            BROWSER_SEARCH = 101,
            BROWSER_FAVORITES = 102,
            BROWSER_HOME = 50,
            VOLUME_MUTE = 32,
            VOLUME_DOWN = 46,
            VOLUME_UP = 48,
            MEDIA_NEXT_TRACK = 25,
            MEDIA_PREV_TRACK = 16,
            MEDIA_STOP = 36,
            MEDIA_PLAY_PAUSE = 34,
            LAUNCH_MAIL = 108,
            LAUNCH_MEDIA_SELECT = 109,
            LAUNCH_APP1 = 107,
            LAUNCH_APP2 = 33,
            OEM_1 = 39,
            OEM_PLUS = 13,
            OEM_COMMA = 51,
            OEM_MINUS = 12,
            OEM_PERIOD = 52,
            OEM_2 = 53,
            OEM_3 = 41,
            OEM_4 = 26,
            OEM_5 = 43,
            OEM_6 = 27,
            OEM_7 = 40,
            OEM_8 = 0,
            OEM_102 = 86,
            PROCESSKEY = 0,
            PACKET = 0,
            ATTN = 0,
            CRSEL = 0,
            EXSEL = 0,
            EREOF = 93,
            PLAY = 0,
            ZOOM = 98,
            NONAME = 0,
            PA1 = 0,
            OEM_CLEAR = 0,
        }
              
        [StructLayout(LayoutKind.Sequential)]
        internal struct HARDWAREINPUT
        {
            internal int uMsg;
            internal short wParamL;
            internal short wParamH;
        }
        #endregion

        #region SCREENSHOTS

        /// <summary>
        /// Takes a screenshot of the whole screen
        /// </summary>
        /// <returns>Returns a bitmap image of the screen</returns>
        public static Bitmap getScreenshot()
        {
            // Create new bitmap object the size of screen
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Creates a new graphic object
            Graphics graphic = Graphics.FromImage(screenshot);

            //Takes the screenshot
            graphic.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            

            //Dispose the graphics object
            graphic.Dispose();

            // Return the bitmap to the user
            return screenshot;
        }

        /// <summary>
        /// Takes a bitmap screenshot of a particular window
        /// </summary>
        /// <param name="processName">The process/window's title</param>
        /// <returns>Bitmap of the window</returns>
        public static Bitmap getScreenshotOfWindow(IntPtr windowHandle)
        {
            //This will hold our window's information
            RECT WINDOW = new RECT();

            ////Get the window information
            //IntPtr window = getWindowHandle(windowTitle);

            //Get window details
            GetWindowRect(windowHandle, out WINDOW);

            //Width and height of window
            int winWidth = WINDOW.Right - WINDOW.Left;
            int winHeight = WINDOW.Bottom - WINDOW.Top;

            //Window size
            Size winSize = new Size(winWidth, winHeight);

            //Our graphics variables
            Bitmap screenshot = new Bitmap(winWidth, winHeight);
            Graphics graphic = Graphics.FromImage(screenshot);

            //Takes the screenshot, starting where the top left corner of the window is, and takes only the size of the window
            graphic.CopyFromScreen(WINDOW.Left, WINDOW.Top, 0, 0, winSize, CopyPixelOperation.SourceCopy);


            //Clean up a bit
            graphic.Dispose();

            //Return the screenshot
            return screenshot;

        }

        public static Bitmap getScreenshotOfWindowRegion(IntPtr windowHandle, Point regionBegin, Point regionEnd)
        {
            //This will hold our window's information
            RECT WINDOW = new RECT();
            

            ////Get the window information
            //IntPtr window = getWindowHandle(windowTitle);

            //Get window details
            GetWindowRect(windowHandle, out WINDOW);

            //Width and height of window
            int winWidth = WINDOW.Right - WINDOW.Left;
            int winHeight = WINDOW.Bottom - WINDOW.Top;

            
            //Window size
            Size winSize = new Size(winWidth, winHeight);

            //RegionSize
            Size regionSize = new Size(regionEnd.X - regionBegin.X, regionEnd.Y - regionBegin.Y);

            //Our graphics variables
            Bitmap screenshot = new Bitmap(regionSize.Width, regionSize.Height);
            Graphics graphic = Graphics.FromImage(screenshot);

            //Takes the screenshot, starting where the top left corner of the window is, and takes only the size of the window
            graphic.CopyFromScreen(WINDOW.Left+regionBegin.X, WINDOW.Top+regionBegin.Y, 0, 0, regionSize, CopyPixelOperation.SourceCopy);

            //Save the BitmapImage
            screenshot.Save("C:\\Users\\ronda\\Desktop\\test.bmp");

            //Clean up a bit
            graphic.Dispose();

            //Return the screenshot
           
            
            return screenshot;

        }

        public  Point GetWindowsUpperLetftCorner(IntPtr windowHandle)
        {
            RECT WINDOW = new RECT();

           
            GetWindowRect(windowHandle, out WINDOW);

            Point TopLeftCorner = new Point(WINDOW.Left, WINDOW.Top);
            return TopLeftCorner;

        }

        public Size GetWindowSize(IntPtr windowHandle)
        {

            //This will hold our window's information
            RECT WINDOW = new RECT();

            ////Get the window information
            //IntPtr window = getWindowHandle(windowTitle);

            //Get window details
            GetWindowRect(windowHandle, out WINDOW);

            //Width and height of window
            int winWidth = WINDOW.Right - WINDOW.Left;
            int winHeight = WINDOW.Bottom - WINDOW.Top;

            //Window size
            Size winSize = new Size(winWidth, winHeight);
            return winSize;
        }
        #endregion

        #region IMAGE RECOGNITON

        /// <summary>
        /// Searches for a bitmap inside a larger one
        /// </summary>
        /// <param name="small">Image (Bitmap) to look for </param>
        /// <param name="large">Image (Bitmap) to look in</param>
        /// <returns>True if image was found, and changes the Point value passed to it to the top left co-ordinates of where the image was found</returns>
        public bool findImage(Bitmap small, Bitmap large, out Point location, int tolerance)
        {
            DateTime time = DateTime.Now;
            //Loop through large images width
            for (int largeX = 0; largeX < large.Width-small.Width; largeX++)
            {
                //And height
                for (int largeY = 0; largeY < large.Height- small.Height; largeY++)
                {
                    //Loop through the small width
                    for (int smallX = 0; smallX < small.Width; smallX++)
                    {
                        //And height
                        for (int smallY = 0; smallY < small.Height; smallY++)
                        {
                            //Get current pixels for both image
                            Color currentSmall = small.GetPixel(smallX, smallY);
                            Color currentLarge = large.GetPixel(largeX + smallX,largeY + smallY);
                            //If they dont match (i.e. the image is not there)

                            if (!colorsSimilar(currentSmall, currentLarge,tolerance))
                                goto nextLoop;
                            //Goto the next pixel in the large image
                        }
                    }
                    //If all the pixels match up, then return true and change Point location to the center co-ordinates where it was found
                    location = new Point(largeX + (small.Width / 2), largeY+ (small.Height / 2));
                    
                    return true;
                  //Go to next pixel on large image
                 nextLoop:
                continue;
                }
               
            }
            //Return false if image is not found, and set an empty point
            location = Point.Empty;
            
            return false;
        }

        public bool findImageInRegion(Bitmap small, Bitmap large, out Point location, int tolerance, Point regionBegin , Point regionEnd)
        {
            //Loop through large images width
            for (int largeX = regionBegin.X; largeX < regionEnd.X - small.Width; largeX++)
            {
                //And height
                for (int largeY = regionBegin.Y; largeY < regionEnd.Y - small.Height; largeY++)
                {
                    //Loop through the small width
                    for (int smallX = 0; smallX < small.Width; smallX++)
                    {
                        //And height
                        for (int smallY = 0; smallY < small.Height; smallY++)
                        {
                            //Get current pixels for both image
                            Color currentSmall = small.GetPixel(smallX, smallY);
                            Color currentLarge = large.GetPixel(largeX + smallX, largeY + smallY);
                            //If they dont match (i.e. the image is not there)

                            if (!colorsSimilar(currentSmall, currentLarge, tolerance))
                                goto nextLoop;
                            //Goto the next pixel in the large image
                        }
                    }
                    //If all the pixels match up, then return true and change Point location to the center co-ordinates where it was found
                    location = new Point(largeX + (small.Width / 2), largeY + (small.Height / 2));

                    return true;
                //Go to next pixel on large image
                nextLoop:
                    continue;
                }

            }
            //Return false if image is not found, and set an empty point
            location = Point.Empty;

            return false;
        }

        /// <summary>
        /// Finds ALL occurences of a smaller image inside a bigger one
        /// </summary>
        /// <param name="small">Image (24 bit Bitmap) to find </param>
        /// <param name="large">Image (Bitmap) to look in</param>
        /// <returns>A list containing Points of the top left of where the image occured</returns>
        public List<Point> findImages(Bitmap small, Bitmap large)
        {
            /* !!! WARNING !!! This can be very slow but can save time in the long term. For instance, you can take a picture of the screen,
             * find and store all "items" (thing you can do stuff to) then get the person/avatar to walk round and handle each money individualy, 
             * and you just acount for the changes in position he has made. 1 big screenshot is better than 20 small ones, 
             * (creates the impression of faster run speed)
             */

            //A new list of image locations
            List<Point> imageLocations = new List<Point>();

            //Loop through large images width
            for (int largeX = 0; largeX < large.Width; largeX++)
            {
                //And height
                for (int largeY = 0; largeY < large.Height; largeY++)
                {
                    //Loop through the small width
                    for (int smallX = 0; smallX < small.Width; smallX++)
                    {
                        //And height
                        for (int smallY = 0; smallY < small.Height; smallY++)
                        {
                            //Get current pixels for both image
                            Color currentSmall = small.GetPixel(smallX, smallY);
                            Color currentLarge = large.GetPixel(largeX + smallX, largeY + smallY);

                            //If they dont match (i.e. the image is not there)
                            if (!colorsMatch(currentSmall, currentLarge))
                                //Goto the next pixel in the large image
                                goto nextLoop;
                        }
                    }
                    //If all the pixels match up, add point to list
                    imageLocations.Add(new Point(largeX, largeY));
                //Go to next pixel on large image
                nextLoop:
                    continue;
                }
            }

            return imageLocations;
        }

        /// <summary>
        /// Finds the first occurence of a color. Starts from top left corner
        /// </summary>
        /// <param name="image">Image to look in</param>
        /// <param name="color">Color to look for</param>
        /// <param name="absolute">If the colors have to be an exact match or not</param>
        /// <param name="tolerance">How close the colors have to be. Read more in the colorsSimilar() method</param>
        /// <returns>True if color found, and changes value of the Point passed to it</returns>
        public bool findColor(Bitmap image, Color color, out Point location, bool absolute = false, int tolerance = 5)
        {
            //Loop through image width
            for (int i = 0; i <= image.Width; i++)
            {
                //And height
                for (int j = 0; j <= image.Height; j++)
                {
                    // If absolute match wanted and their is an absolute match between color and current pixel, return true and change Point location
                    if (absolute && colorsMatch(color, image.GetPixel(i, j)))
                    {
                        location = new Point(i, j);
                        return true;
                    }
                    // If colors similar otherwise, change locatio and return true
                    else if (colorsSimilar(color, image.GetPixel(i, j), tolerance))
                    {
                        location = new Point(i, j);
                        return true;
                    }
                }
            }
            //Return false if color not found
            location = Point.Empty;
            return false;
        }

        /// <summary>
        /// Searches through an image for a particular color and adds all occurences to a Point List
        /// </summary>
        /// <param name="image">Image (Bitmap) to look in</param>
        /// <param name="color">Color to search for</param>
        /// <param name="absolute">If the colors have to be an exact match or not</param>
        /// <param name="tolerance">How close the colors have to be. Read more in the colorsSimilar() method</param>
        /// <returns>A list of point where the color has occured</returns>
        public List<Point> findColors(Bitmap image, Color color, bool absolute = false, int tolerance = 5)
        {
            //Create a new list
            List<Point> colorLocations = new List<Point>();
            //Loop through image width
            for (int i = 0; i <= image.Width; i++)
            {
                // And height
                for (int j = 0; j <= image.Height; j++)
                {
                    //If absolute match wanted and their is an absolute match, add point onto lis
                    if (absolute && colorsMatch(color, image.GetPixel(i, j)))
                        colorLocations.Add(new Point(i, j));
                    else
                    {
                        //If colors are similar otherwise, add Point onto list
                        if (colorsSimilar(color, image.GetPixel(i, j), tolerance))
                            colorLocations.Add(new Point(i, j));
                    }
                }
            }
            //Return list of color locations
            return colorLocations;
        }

        /// <summary>
        /// Sees if 2 colors are an EXACT  match
        /// </summary>
        /// <param name="one">First color to compare</param>
        /// <param name="two">Second color to compare</param>
        /// <returns>True or false depending on if there the same</returns>pect of the color
        public static bool colorsMatch(Color one, Color two)
        {
            //Compares the R,G & B as
            if (one.B == two.B && one.G == two.G && one.R == two.R) return true;
            return false;
        }

        /// <summary>
        /// Compares 2 colors and sees if they are SIMILAR
        /// </summary>
        /// <param name="one">First color to compare</param>
        /// <param name="two">Second color to compare</param>
        /// <param name="tolerance">Differance allowed. Higher equals more different colors and vice versa</param>
        /// <returns>True or false on colors being similar</returns>
        public static bool colorsSimilar(Color one, Color two, int tolerance)
        {
            //If any colors aspects difference if bigger than the tolerance, return false
            if (Math.Abs(one.B - two.B) >= tolerance || Math.Abs(one.G - two.G) >= tolerance || Math.Abs(one.R - two.R) >= tolerance) return false;

            return true;
        }

        #endregion

        #region WINDOW HANDLING

        /// <summary>
        /// Returns the main window handle for the given process
        /// </summary>
        /// <param name="windowName">String with window title</param>
        /// <param name="contains">True/False does the window title have to match exactly. False means it will check if the title 
        /// contains the string passed to it
        /// </param>
        /// <returns>A window handle</returns>
        public static IntPtr getWindowHandle(string windowTitle)
        {
            IntPtr hWnd;
            hWnd = (IntPtr)0;
            Process[] processes = Process.GetProcesses();
            if (processes.Length > 0)
            {
                Thread.Sleep(3000);
                foreach (Process process in processes)
                {
                    if (process.MainWindowTitle == windowTitle)
                    {
                        hWnd = process.MainWindowHandle;
                        break;
                    }
                }
            }
            return hWnd;
        }

        /// <summary>
        /// Sets a particular window to the front
        /// </summary>
        /// <param name="windowHandle">The window's handle</param>
        public Boolean setFrontWindow(IntPtr windowHandle)
        {
            //Get the main window handle and set it to the foreground
            return BringWindowToTop(windowHandle);
        }

        /// <summary>
        /// Shows a window
        /// </summary>
        /// <param name="windowHandle">The window's handle</param>
        public static void showWindow(IntPtr windowHandle)
        {
            ShowWindow(windowHandle, 9);
            return;
        }

        #endregion

        #region ANTI-BANS
        // Note that human mouse movement is in the OS CONTROL region

        /// <summary>
        /// Pauses the thread for a random number of milliseconds in range. Randomly delays create a human like pause,
        /// but you can also use the fact that some method like findImage and findColor can take several seconds so that counts as a pause
        /// </summary>
        /// <param name="lower">Minimum delay time</param>
        /// <param name="upper">Maximum delay time</param>
        public void delay(int lower = 10, int upper = 30)
        {
            Thread.Sleep(random(lower, upper));
            return;
        }

        /// <summary>
        /// Pauses the thread for the given time
        /// </summary>
        /// <param name="time">No of milliseconds to delay for.</param>
        public void delay(int time = 10000)
        {
            Thread.Sleep(time);
            return;
        }

        /// <summary>
        /// Generates a random number  between the ranges given. Doing stuff randomly makes the program different everytime (more human like)
        /// </summary>
        /// <param name="lower">Minimum number possible</param>
        /// <param name="upper">Maxium number possible</param>
        /// <returns>A random number</returns>
        public static int random(int lower, int upper)
        {
            return new Random().Next(lower, upper);
        }

        #endregion

        #region AUTOMATION

        // Allows users to esily control mouse position
        public Point mousePosition
        {
            get
            {
                return Cursor.Position;
            }
            set
            {
                moveMouse(value);
            }
        }

        #region LEFT CLICK

        /// <summary>
        /// Causes the mouse to left click at its current position
        /// </summary>
        public void leftClick()
        {
            // Mouse down
            leftDown();
            //Wait
            Thread.Sleep(new Random().Next(10, 30));
            //Mouse up
            leftUp();
            return;
        }

        /// <summary>
        /// Makes the left mouse button go down
        /// </summary>
        public void leftDown()
        {
            // Mouse down
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        }

        /// <summary>
        /// Makes the left mouse button go up
        /// </summary>
        public void leftUp()
        {
            //Mouse up
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        #endregion

        #region RIGHT CLICK

        /// <summary>
        /// Causes the mouse to right click at its current position
        /// </summary>
        public void rightClick()
        {
            //Mouse down
            rightDown();
            //Wait a bit
            Thread.Sleep(new Random().Next(10, 30));
            //Mouse up
            rightUp();
            return;
        }

        /// <summary>
        /// Makes the right mouse button go down
        /// </summary>
        public void rightDown()
        {
            //Mouse down
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
        }

        /// <summary>
        /// Makes the right mouse button go up
        /// </summary>
        public void rightUp()
        {
            //Mouse up
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }

        #endregion

        #region MOVEMENT

        /// <summary>
        /// Moves the mouse in a linear straight line to the target position
        /// </summary>
        /// <param name="targetX">X co-ordinate of target</param>
        /// <param name="targetY">Y co-ordinate of target</param>
        /// <param name="human">Human mouse movement or just assign position</param>
        /// <param name="steps">Number of steps to take. More means a slower but smoother move, less means a faster but more jerky movement</param>
        public bool moveMouse(Point target, bool human = true, int steps = 100)
        {
            /* If the mouse moves to slowly when traveling over buttons/boxes/dropdowns (anything to click) it can stop, 
            and will then jump to the target due to the fail safe. You can change the delay time, but the best thing to do is to try out 
            different numbers of steps and get the right balance */

            //If mouse movement is not human
            if (!human)
            {
                // Set mouse to target position
                Cursor.Position = target;

                return true;
            }

            // Word out how far the cursor must move for each step. It will then change by this much each step
            int xStep = (target.X - Cursor.Position.X) / steps;
            int yStep = (target.Y - Cursor.Position.Y) / steps;

            // Loop through the steps
            for (int i = 0; i <= steps; i++)
            {
                // Work out the new mouse postion
                int xPosition = Cursor.Position.X + xStep;
                int yPosition = Cursor.Position.Y + yStep;

                //Move the mouse to its new position
                Cursor.Position = new Point(xPosition, yPosition);

                //Delay a few milliseconds
                Thread.Sleep(5);

            }
            // As a fail safe assigns the mouse the target position 
            Cursor.Position = target;

            //If position is right
            if (Cursor.Position == target)
                //return true
                return true;
            else
                return false;
        }

        /// <summary>
        /// Moves the mouse relative to the window. eg if you specified for it to move  to 10,10 over the window "Notepad" 
        /// it would move 10,10 into the top left of Notepad. A bit like local scope where 0,0 is the top left corner of the window given.
        /// </summary>
        /// <param name="windowHandle">Window handle</param>
        /// <param name="targetX">Trget X position</param>
        /// <param name="targetY">Target Y position</param>
        /// <param name="human">Human or not mouse movement</param>
        /// <param name="steps">Number of steps to take</param>
        /// <returns>True or false depending on outcome</returns>
        public bool moveMouseRelative(IntPtr windowHandle, Point target, bool human = true, int steps = 100)
        {
            //Will sore window details
            RECT WINDOW = new RECT();

            //Get window details
            if (!GetWindowRect(windowHandle, out WINDOW))
                return false;

            //Move the mouse
            if (!moveMouse(new Point(WINDOW.Left + target.X, WINDOW.Top + target.Y), human, steps))
                return false;

            return true;
        }

        /// <summary>
        /// Drags the mouse
        /// </summary>
        /// <param name="start">Drag start position</param>
        /// <param name="end">Drag end position</param>
        /// <param name="human">Human mouse movement or not</param>
        /// <param name="steps">Number of steps to take</param>
        /// <returns>True or false on outcome</returns>
        public bool dragMouse(Point start, Point end, bool human = true, int steps = 100)
        {
            //Move mouse to start point
            moveMouse(start, human, steps);
            //Left button down
            leftDown();
            //Drag mouse to end point
            moveMouse(end, human, steps);
            // Left button up
            leftUp();

            // if mouse position is right 
            if (Cursor.Position == end)
                //Return true
                return true;
            return false;
        }

        /// <summary>
        /// Drags the mouse relative to a window
        /// </summary>
        /// <param name="windowHandle">The window handle you want to move relative to</param>
        /// <param name="start">Drag start position</param>
        /// <param name="end">Drag end position</param>
        /// <param name="human">Human mouse movement or not</param>
        /// <param name="steps">Number of steps to take</param>
        /// <returns>True or false on outcome</returns>
        public bool dragMouseRelative(IntPtr windowHandle, Point start, Point end, bool human = true, int steps = 100)
        {
            //Will sore window details
            RECT WINDOW = new RECT();

            //Get window details
            if (!GetWindowRect(windowHandle, out WINDOW))
                return false;

            //Move mouse to start point
            moveMouse(new Point(WINDOW.Left + start.X, WINDOW.Top + start.Y), human, steps);
            //Left button down
            leftDown();
            //Drag mouse to end point
            moveMouse(new Point(WINDOW.Left + end.X, WINDOW.Top + end.Y), human, steps);
            // Left button up
            leftUp();

            // if mouse position is right 
            if (Cursor.Position == end)
                //Return true
                return true;
            return false;
        }

        #endregion

        /// <summary>
        /// New little thing that simulates a slight "jiggle" of the mouse, like a humans unsteady hands. Be aware this has had little testing
        /// </summary>
        public void mouseJiggle()
        {
            //Work out a slight change in mouse position
            int xChange = new Random().Next(-10, 10);
            int yChange = new Random().Next(-10, 10);

            //Move mouse a few pixels
            moveMouse(new Point(Cursor.Position.X + xChange, Cursor.Position.Y + yChange), true, 5);
            //Wait a bit
            Thread.Sleep(new Random().Next(20, 60));
            // Move mouse back to original point
            moveMouse(new Point(Cursor.Position.X - xChange, Cursor.Position.Y - yChange), true, 5);

            return;
        }

        /// <summary>
        /// Simulates key preses. Read about how to use here => www.msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send.aspx
        /// </summary>
        /// <param name="key">String of keys to be presses</param>
        public void sendKeys(string keys, int delay = 300)
        {
            // Loop through each key in keys
            foreach (char key in keys)
            {
                //Send keys to the system
                SendKeys.Send(key.ToString());

                Thread.Sleep(new Random().Next(delay - 30, delay + 30));
            }

            return;
        }

        #endregion

        #region HOTKEYS

        // Store the register hot keys, and the keys currently down at this time
        public List<Keys> hotKeys, keysDown;

        // If hotKeys monitor is running or not
        private bool running = false;

        /// <summary>
        /// Starts monitoring
        /// </summary>
        public void startMonitoring()
        {
            running = true;
        }

        /// <summary>
        /// Stops monitoring
        /// </summary>
        public void stopMonitoring()
        {
            running = false;
        }

        /// <summary>
        /// Registers a hot key
        /// </summary>
        /// <param name="key">The key to register</param>
        public void registerHotKey(Keys key)
        {
            hotKeys.Add(key);
        }

        /// <summary>
        /// Checks all registered hotkeys, and adds any that are down to the keysDown list
        /// </summary>
        public void checkHotKeys()
        {
            // Clears the keyDown list of all those before
            keysDown.Clear();

            // Loop through all the hotkeys
            foreach (Keys key in hotKeys)
            {
                // If keys is down
                if (keyDown(key))
                    hotKeyAlert(key);

            }

            // Stop if running == false
            if (!running)
                return;

            // Wait a bit
            delay(10);

            // Start again
            checkHotKeys();

        }

        /// <summary>
        /// Called when a Hotkey is detected down
        /// </summary>
        /// <param name="key">Hotkey that is down</param>
        public void hotKeyAlert(Keys key)
        {
            keysDown.Add(key); // Add it to the key down list
            // Do somethind else...
        }

        /// <summary>
        /// Checks if the key given is currently down
        /// </summary>
        /// <param name="key">The key to check  READ => msdn.microsoft.com/en-us/library/system.windows.forms.keys.aspx</param>
        /// <returns>Tru/False</returns>
        public bool keyDown(Keys key)
        {
            //Returns if the key is down
            return GetAsyncKeyState(key) == -32767;
        }

        #endregion

        #region UTILITY

       public IntPtr GetGameHandle()
        {
            IntPtr Handle = FindWindow("Arena", "Total War: Arena");
            return Handle;
        }

        public bool  SetForgroundWindow(IntPtr Handle)
        {
            if (SetForegroundWindow(Handle))
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

       public void SendInputKeyPress(ScanCodeShort key)
        {
            INPUT[] Inputs = new INPUT[2];
            INPUT Input = new INPUT();

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[0] = Input;

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            Input.U.ki.dwFlags = KEYEVENTF.KEYUP;
            Inputs[1] = Input;

            SendInput(2, Inputs, INPUT.Size);
        }


        #endregion

    }
}