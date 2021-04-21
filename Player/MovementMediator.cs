using System;
using UnityEngine;
using GameServices;

namespace Components.Mediators
{

    class MovementMediator
    {
        private Action left;
        private Action right;

        public MovementMediator(Action left, Action right) =>
            (this.left, this.right) = (left, right);

        public void SubscribeOnInputEvents()
        {
            InputGameService.Instance
                .Add(left, Input.GetKey, KeyCode.A)
                .Add(right, Input.GetKey, KeyCode.D);
        }
    }
}