using System;
using System.Collections.Generic;
using Core;

namespace Controllers
{

    class PlayerController : Controller
    {
        private Dictionary<string, Action> _events;
        public override Dictionary<string, Action> events { get => _events; private set; }

        public PlayerController() : base()
        { }

        
    }
}