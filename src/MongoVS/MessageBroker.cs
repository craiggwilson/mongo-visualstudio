using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio
{
    [Export(typeof(IMessageBroker))]
    internal class MessageBroker : IMessageBroker
    {
        private readonly Dictionary<Type, List<Action<object>>> _subscribers;

        public MessageBroker()
        {
            _subscribers = new Dictionary<Type, List<Action<object>>>();
        }

        public void Publish<TMessage>(TMessage message)
        {
            List<Action<object>> list;
            if (!_subscribers.TryGetValue(typeof(TMessage), out list))
                return;

            list.ForEach(x => x(message));
        }

        public void Subscribe<TMessage>(Action<TMessage> callback)
        {
            List<Action<object>> list;
            if (!_subscribers.TryGetValue(typeof(TMessage), out list))
                _subscribers[typeof(TMessage)] = list = new List<Action<object>>();

            list.Add(o => callback((TMessage)o));
        }
    }
}
