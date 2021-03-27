using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    
    ///<summary>
    ///Базовый класс предназначенный для взаимодействия игрока с системой
    ///</summary>
    public abstract class View : MonoBehaviour
    {
        ///<summary>
        ///Содержит проверку на нажатие клавиши и реакцию на нажатие игрока
        ///</summary>
        private abstract Dictionary<KeyCode, Action> _inputs {get;}
        private abstract void SendToController<T>(T data);
        
        private void Update()
        {
            
            foreach (KeyCode code in _inputs.Keys)
            {
                if (Input.GetButton(code))
                {
                    _inputs[code].Invoke();
                }
            }
        }

    }
}