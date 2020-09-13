using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    class Interaction : MonoBehaviour
    {
        private void Start()
        {
            
        }
    }
    #region Enums Definitions
    enum PlayerState
    {
        Alive, Died
    }
    enum MoveDirection
    {
        Forward, Up, Left, Right
    }
    enum PlayerPosition
    {
        Left, Middle, Right, Jumped
    }
    #endregion
    #region Interfaces definitions
    interface ICommand
    {
        void Execute();
    }
    #endregion

    class Player : MonoBehaviour
    {
        public delegate void Action();
        public GameObject PlayerObject 
        { 
            get {return GetComponent<GameObject>();} 
        }
        
        ///Move player in said direction
        public void MoveTowards(MoveDirection direction)
        {
            var directionCases = new Dictionary<MoveDirection,Action>()
            {
                {MoveDirection.Forward,() => new Commands.MoveForward().Execute()},
                {MoveDirection.Up,() => new Commands.MoveUp().Execute()},
                {MoveDirection.Left,() => new Commands.MoveLeft().Execute()},
                {MoveDirection.Right,() => new Commands.MoveRight().Execute()}
            };
            directionCases[direction].Invoke();
        }
        #region Command pattern definitions
        private static class Commands
        {
            public class MoveUp : ICommand
            {
                public void Execute()
                {
                    PlayerObject.transform.Translate(Vector3.up);
                }
            }
            public class MoveForward : ICommand
            {
                public void Execute()
                {
                    PlayerObject.transform.Translate(Vector3.up);
                }
            }
            public class MoveRight : ICommand
            {
                public void Execute()
                {
                    PlayerObject.transform.Translate(Vector3.up);
                }
            }
            public class MoveLeft : ICommand
            {
                public void Execute()
                {
                    PlayerObject.transform.Translate(Vector3.up);
                }
            }
        }
        #endregion
    }
}
