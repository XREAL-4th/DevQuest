using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public struct BindOptions
    {
        public bool once;

        public static BindOptions defaultOption = new() { once = false };
    }

    public class BindObject
    {
        public bool once = false;
        public int id;

        public IBind bind;
        public Action<KeyCode[], BindObject> callback = (_, __) => { };
        public Action elseCallback = () => { };

        public BindObject(BindOptions options, IBind bind)
        {
            once = options.once;
            this.bind = bind;
            id = KeyBindManager.Instance.binds.Count;
        }
    }
}