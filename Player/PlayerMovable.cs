using System;
using Exceptions;
using UnityEngine;
using Components.Abstract;
using Components.Mediators;

namespace Components.Concrete
{

    class PlayerMovable : MonoBehaviour, IMovable
    {
        [SerializeField] private float movementSpeed = 1f;
        private MovementMediator mediator;
        private int _currentPlayerPosition = 0;
        private Rigidbody movementObject; 

        private void Start()
        {
            mediator = new MovementMediator(MoveLeft, MoveRight);
            mediator.SubscribeOnInputEvents();
            movementObject = GetComponent<Rigidbody>();
        }

        public void MoveLeft()
        {
            ValidateMovement((int) MoveConsts.LeftBorder);
            Move(-((int) MoveConsts.MovementStep));    
        }

        public void MoveRight()
        {
            ValidateMovement((int) MoveConsts.RightBorder);
            Move((int) MoveConsts.MovementStep);  
        }

        private void ValidateMovement(int borderValue)
        {
            if (_currentPlayerPosition == borderValue)
            {
                throw new BorderCollisionException();
            }
        }

        private void Move(int amount)
        {
            _currentPlayerPosition += amount;
            movementObject.MovePosition(Vector3.MoveTowards(transform.position, new Vector3((float) amount, 0, 0), movementSpeed));
        }

        void IMovable.MoveLeft()
        {
            this.MoveLeft();
        }

        void IMovable.MoveRight()
        {
            this.MoveRight();
        }
    }

    enum MoveConsts : int
    {
        LeftBorder = -3,
        RightBorder = 3,
        MovementStep = 3
    }
}