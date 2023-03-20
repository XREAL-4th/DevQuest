using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public class OrBind : Bind
    {
        public OrBind(params IBind[] binds) : base(binds) { }

        public override bool IsKeyPressed(out KeyCode[] res)
        {
            List<KeyCode> list = new();
            foreach (KeyBind keybind in binds)
            {
                if (keybind.IsKeyPressed(out KeyCode[] bindKeys))
                {
                    list.AddRange(bindKeys);
                }
            }
            res = list.ToArray();
            return list.Any();
        }
    }
}