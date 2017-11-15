using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Kinect_MouseControl
{
    class Mouse
    {
        #region User32
        /// <summary>
        /// WinAPI를 C#에서 호출하는 함수입니다
        /// </summary>
        /// <param name="dwFlags">마우스 이벤트에 대한 플래그</param>
        /// <param name="dx">좌표 X의 값</param>
        /// <param name="dy">좌표 Y의 값</param>
        /// <param name="dwData">휠이나 X버튼에 대한 추가 인수</param>
        [DllImport("user32.dll")]
        static extern void mouse_event([In]int dwFlags, [In]int dx, [In]int dy, [In]int dwData, [In]IntPtr dwExtraInfo);
        #endregion

        #region Enum
        /// <summary>
        /// mouse_event에서 쓰이는 상수들을 모아둔 열거체입니다
        /// </summary>
        [Flags()]
        enum MouseEventFlag
        {
            Absolute = 0x8000,  //0000 0000 0000
            LeftDown = 0x0002,  //0000 0000 0010
            LeftUp = 0x0004,    //0000 0000 0100
            MiddleDown = 0x0020,//0000 0010 0000
            MiddleUp = 0x0040,  //0000 0100 0000
            Move = 0x0001,      //0000 0000 0001
            RightDown = 0x0008, //0000 0000 1000
            RightUp = 0x0010,   //0000 0001 0000
            Wheel = 0x0800,     //1000 0000 0000
            XDown = 0x0080,     //0000 1000 0000
            XUp = 0x0100,       //0001 0000 0000
            HWheel = 0x1000,
        }

        /// <summary>
        /// 마우스 버튼에 대한 열거체입니다
        /// </summary>
        [Flags]
        public enum Buttons
        {
            Left,
            Right,
            Middle,
            X,
        }
        #endregion

        #region Method
        /// <summary>
        /// 현재 좌표를 기준으로 마우스를 움직입니다
        /// </summary>
        /// <param name="X">가로로 움직일 양</param>
        /// <param name="Y">세로로 움직일 양</param>
        public static void Move(int X, int Y)
        {
            mouse_event((int)MouseEventFlag.Move, X, Y, 0, IntPtr.Zero);
        }
        #endregion Method 
    }
}
