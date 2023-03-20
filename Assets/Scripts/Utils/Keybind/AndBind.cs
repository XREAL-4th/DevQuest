using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public class AndBind : Bind
    {
        public AndBind(params IBind[] binds) : base(binds) { }

        public override bool IsKeyPressed(out KeyCode[] res)
        {
            List<KeyCode> list = new();
            foreach (IBind keybind in binds)
            {
                if (keybind.IsKeyPressed(out KeyCode[] bindKeys))
                {
                    list.AddRange(bindKeys);
                }
                else
                {
                    res = null;
                    return false;
                }
            }
            res = list.ToArray();
            return true;
        }
    }
}