using UnityEngine;

namespace Assets.Scripts.Utils.Keybind
{
    public interface IKeyBind : IBind
    {
        void Init(KeyCode[] codes);
        KeyCode[] GetKeys();
    }

    public class KeyBind : Bind, IKeyBind
    {
        KeyCode key;

        public virtual void Init(KeyCode[] codes) => key = codes[0];

        public override bool IsKeyPressed(out KeyCode[] res)
        {
            res = new[] { key };
            return Input.GetKey(key);
        }

        public virtual KeyCode[] GetKeys() => new[] { key };
    }
}