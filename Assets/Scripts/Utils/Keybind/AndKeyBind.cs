using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public class AndKeyBind : KeyBind
    {
        KeyCode[] keys;

        public override void Init(KeyCode[] codes) => keys = codes;

        public override bool IsKeyPressed(out KeyCode[] res)
        {
            foreach (KeyCode code in keys)
            {
                if (!Input.GetKey(code))
                {
                    res = null;
                    return false;
                }
            }
            res = keys;
            return true;
        }

        public override KeyCode[] GetKeys() => keys;
    }
}