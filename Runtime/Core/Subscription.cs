using System;
using UnityEngine;

namespace Stinkysteak.SimplePubsub
{
    /// <summary>
    /// Relation between Listener and Signal Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Subscription<T> : ISubscription where T : ISignal
    {
        private readonly Action<T> _callback;
        private readonly bool _oneTime;
        private readonly Type _subscribedSignal;

        public void Invoke(ISignal signal)
        {
            if ((Listener as MonoBehaviour) == null)
            {
                SignalManager.Unsubscribe(Listener, signal.GetType());
                return;
            }

            _callback?.Invoke((T)signal);
        }

        public Subscription(Action<T> callback, bool oneTime)
        {
            _subscribedSignal = typeof(T);
            _callback = callback;
            _oneTime = oneTime;
        }

        public Type SubscribedSignal => _subscribedSignal;
        public object Listener => _callback.Target;
        public bool OneTime => _oneTime;
        public Action<T> Callback => _callback;
    }
}