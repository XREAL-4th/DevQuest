
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Scripts.Utils.Singletons;
using System.Linq;

namespace Assets.Scripts.Utils.Keybind
{
    public class KeyBindManager : LazyDDOLSingletonMonoBehaviour<KeyBindManager>
    {
        public readonly List<BindObject> binds = new();
        BindObject LastBind => binds.LastOrDefault();

        void Update()
        {
            for (int i = 0; i < binds.Count; i++)
            {
                BindObject bind = binds[i];
                RunBind(bind);
            }
            if(LastBind != null) RunBind(LastBind);
        }

        void RunBind(BindObject bind)
        {
            if (bind.bind.IsKeyPressed(out KeyCode[] keyCodes))
            {
                bind.callback(keyCodes, bind);
                if(bind.once) binds.Remove(bind);
            }
            else bind.elseCallback();
        }

        T CreateKeyBind<T>(params KeyCode[] keyCodes) where T : IKeyBind, new()
        { 
            T keyBind = new ();
            keyBind.Init(keyCodes);
            return keyBind;
        }
        public KeyBindManager Bind(params KeyCode[] keyCodes) => Bind(BindOptions.defaultOption, keyCodes);
        public KeyBindManager Bind(BindOptions options, params KeyCode[] keyCodes) => Bind<OrKeyBind>(options, keyCodes);
        public KeyBindManager Bind<T>(params KeyCode[] keyCodes) where T : KeyBind, new() => Bind<T>(BindOptions.defaultOption, keyCodes);
        public KeyBindManager Bind<T>(BindOptions options, params KeyCode[] keyCodes) where T : KeyBind, new()
        {
            binds.Add(new BindObject(options, CreateKeyBind<T>(keyCodes)));
            return this;
        }

        public KeyBindManager GetID(out int id)
        {
            id = LastBind.id;
            return this;
        }
        public KeyBindManager UnBind(int id)
        {
            int index = binds.FindIndex(bind => bind.id == id);
            if(index != -1) binds.RemoveAt(index);
            return this;
        }

        public KeyBindManager And(params KeyCode[] keyCodes) => And<OrKeyBind>(keyCodes);
        public KeyBindManager And<T>(params KeyCode[] keyCodes) where T : KeyBind, new()
        {
            LastBind.bind = new AndBind(LastBind.bind, CreateKeyBind<T>(keyCodes));
            return this;
        }

        public KeyBindManager Or(params KeyCode[] keyCodes) => Or<OrKeyBind>(keyCodes);
        public KeyBindManager Or<T>(params KeyCode[] keyCodes) where T : KeyBind, new()
        {
            LastBind.bind = new OrBind(LastBind.bind, CreateKeyBind<T>(keyCodes));
            return this;
        }

        public KeyBindManager Then(Action callback) => Then((codes, bind) => callback());
        public KeyBindManager Then(Action<BindObject> callback) => Then((codes, bind) => callback(bind));
        public KeyBindManager Then(Action<KeyCode[]> callback) => Then((codes, bind) => callback(codes));
        public KeyBindManager Then(Action<KeyCode[], BindObject> callback)
        {
            LastBind.callback = callback;
            return this;
        }

        public KeyBindManager Else(Action elseCallback)
        {
            LastBind.elseCallback = elseCallback;
            return this;
        }
    }
}