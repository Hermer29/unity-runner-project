using System;
using System.Collections.Generic;
using Utilities;

namespace Core
{
    ///<summary>
    ///Класс связующее звено модели и представления
    ///</summary>
    public abstract class Controller
    {
        private List<EventContainer> subbed;

        ///<summary>
        ///Словарь сообщений от представления к модели
        ///</summary>
        public abstract Dictionary<string, Action> events {get; set;}

        protected Controller()
        {
            subbed = new List<EventContainer>();
        }

        public void SubscribeOnEvent(string name, Action value)
        {
            subbed.Add(new EventContainer(events[name], value));
        }

        public void UnsubscribeAll()
        {
            subbed.ForEach(x => x.Unsubscribe());
        }

        public void TriggerEvent(string name)
        {
            events[name].Invoke();
        }

        ~Controller()
        {
            UnsubscribeAll();
        }
    }    
}