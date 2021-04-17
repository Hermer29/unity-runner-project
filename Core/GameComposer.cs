using System;
using GameServices;
using UnityEngine;

namespace Core
{

    [RequireComponent(typeof(InputGameService))]
    class GameComposer : MonoBehaviour
    {
        public GameCycleService GameCycle { get; private set; }

        private void Start()
        {
            GameCycle = new GameCycleService();
        }
    }
}