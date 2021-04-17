using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameServices
{

    class InputGameService : MonoBehaviour
    {   

        List<(KeyCode keyCode, Predicate<KeyCode> predicate, Action action)> keycodes;

        private void Start()
        {
            keycodes = new List<(KeyCode keyCode, Predicate<KeyCode> predicate, Action action)>() 
            {
                (KeyCode.A, Input.GetKey, () => print("Test"))
            };
        }

        private void Update()
        {
            foreach (var key in keycodes)
            {
                if (key.predicate.Invoke(key.keyCode))
                {
                    key.action.Invoke();
                }
            }
        }
    }
}