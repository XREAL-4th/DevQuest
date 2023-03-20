using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public interface IBind
    {
        bool IsKeyPressed(out KeyCode[] res);
    }

    public abstract class Bind : IBind
    {
        public IBind[] binds;

        public Bind(params IBind[] binds) => this.binds = binds;

        public abstract bool IsKeyPressed(out KeyCode[] res);
    }
}