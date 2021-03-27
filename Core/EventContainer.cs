using System;

namespace Utilities
{
    class EventContainer
    {
        private Action _publisher;
        private Action _subscriber;
        
        public EventContainer(ref Action publisher, ref Action subscriber)
        {
            _publisher = publisher;
            _subscriber = subscriber; 
            publisher += subscriber;
        }

        public void Unsubscribe()
        {
            _publisher -= _subscriber;
        }
    }
}