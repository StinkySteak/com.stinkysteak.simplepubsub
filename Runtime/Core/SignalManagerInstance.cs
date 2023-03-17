using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stinkysteak.SimplePubsub
{
    internal class SignalManagerInstance : MonoBehaviour
    {
        public static SignalManagerInstance Instance { get; private set; }

        private void Awake()
            => Instance = this;

        private readonly List<ISubscription> _subscriptions = new();

        public void Subscribe<T>(Action<T> callback, bool oneTime = false) where T : ISignal
            => _subscriptions.Add(new Subscription<T>(callback, oneTime));

        public void Unsubscribe(object listener, Type signalType)
        {
            for (int i = 0; i < _subscriptions.Count; i++)
            {
                if (_subscriptions[i].Listener == listener && _subscriptions[i].SubscribedSignal == signalType)
                {
                    _subscriptions.RemoveAt(i);
                    return;
                }
            }

            Debug.LogError($"[SignalManager]: Failed to Unsubscribe: {listener} typeof: {signalType}");
        }

        public void Publish(ISignal signal)
        {
            Type signalType = signal.GetType();

            for (int i = 0; i < _subscriptions.Count; i++)
            {
                ISubscription subscription = _subscriptions[i];

                if (subscription.SubscribedSignal != signalType) continue;

                subscription.Invoke(signal);

                if (subscription.OneTime)
                    Unsubscribe(subscription.Listener, signal.GetType());
            }
        }
    }
}