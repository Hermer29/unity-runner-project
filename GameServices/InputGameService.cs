using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameServices
{

    partial class InputGameService : MonoBehaviour
    {   
        public static InputGameService Instance;
        private List<KeyContainer> keycodes;

        private void Start()
        {
            Instance = this; 
            keycodes = new List<KeyContainer>();
        }

        public InputGameService Add(Action action, Predicate<KeyCode> predicate, params KeyCode[] keys)
        {
            keycodes.Add(new KeyContainer(action, predicate, keys));
            return this;
        }

        private void Update()
        {
            keycodes.ForEach(x => x.TryCheckKeys());
        }
    }
}