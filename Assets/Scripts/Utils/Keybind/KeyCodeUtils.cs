using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    static class KeyCodeUtils
    {
        public static KeyCode[] 
            Numberics = new []{ 
                KeyCode.Alpha0,
                KeyCode.Alpha1,
                KeyCode.Alpha2,
                KeyCode.Alpha3,
                KeyCode.Alpha4,
                KeyCode.Alpha5,
                KeyCode.Alpha6,
                KeyCode.Alpha7,
                KeyCode.Alpha8,
                KeyCode.Alpha9,
            },
            Horizontal = new[]
            {
                KeyCode.A, 
                KeyCode.D, 
                KeyCode.LeftArrow, 
                KeyCode.RightArrow
            },
            Vertical = new[]
            {
                KeyCode.W,
                KeyCode.S,
                KeyCode.UpArrow,
                KeyCode.DownArrow
            };
    }
}