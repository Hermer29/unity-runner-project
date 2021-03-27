using System;
using Utilities;

namespace Core
{
    public abstract class Model
    {

        private Dictionary<string, (Type type, dynamic value, Action onValueChange)> _data;
        private List<EventContainer> _events;

        protected Model()
        {
            _events = new List<EventContainer>();
        }

        public void SetData<T>(string which, T value)
        {
            try
            {
                if(value is not _data[which].type)
                    throw new InvalidCastException($"Не удалось привести {value} к первозданному типу ячейки {_data[which].type} (передан {value.GetType()})");
            }
            catch(KeyNotFoundException)
            {
                throw new InvalidOperationException($"Ключ {which} не найден. Сначала создайте его с помощью метода CreateData");
            }
            
            _data[which].value = value;
        }

        public void CreateData<T>(string name, T value = null)
        {
            if(_data.ContainsKey(name))
                throw new InvalidOperationException("Такой ключ уже существует");

            _data.Add(name, (value.GetType(), value, new Action()));
            
        }

        public void SubscribeOnValueChange(string name, Action value)
        {
            _events.Add(new EventContainer(_data[name].onValueChange, value));
        }

        public void UnsubscribeAll()
        {
            Parallel.Invoke(_events.ToArray().Select(x => x.Unsubscribe));
        }

        public T GetData<T>(string name)
        {
            return _data[name].value;
        }

        ~Model()
        {
            UnsubscribeAll();
        }
    }
}