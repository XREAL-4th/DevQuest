using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public class OrKeyBind : KeyBind
    {
        KeyCode[] keys;

        public override void Init(KeyCode[] codes) => keys = codes;

        public override bool IsKeyPressed(out KeyCode[] res)
        {
            List<KeyCode> list = new();
            foreach (KeyCode code in keys)
            {
                if (Input.GetKey(code)) list.Add(code);
            }
            res = list.ToArray();
            return list.Any();
        }

        public override KeyCode[] GetKeys() => keys;
    }
}