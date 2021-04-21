using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace GameServices
{
    
    partial class InputGameService : MonoBehaviour
    {
        private class KeyContainer
        {
            
            private List<KeyCode> _keyCodes;
            private Predicate<KeyCode> _predicate;
            private Action _action;
            public bool isPressed => _keyCodes.Select(_predicate.Invoke).Aggregate((a, x) => a &= x);

            public void TryCheckKeys()
            {
                if (isPressed)
                {
                    _action.Invoke();
                }
            }

            public KeyContainer(Action action, Predicate<KeyCode> predicate, params KeyCode[] keyCodes)
            {
                _keyCodes = keyCodes.ToList();
                _predicate = predicate;
                _action = action;
            }
        }
    }
}