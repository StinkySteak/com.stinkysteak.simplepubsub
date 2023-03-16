using System.Collections.Generic;
using UnityEngine;
using System;

public class SignalManager : MonoBehaviour
{
    public static SignalManager Instance { get; private set; }

    private void Awake()
        => Instance = this;

    private readonly List<ISubscription> _subscriptions = new();

    public void Subscribe<T>(Action<T> callback) where T : ISignal
        => _subscriptions.Add(new Subscription<T>(callback));

    public void Publish(ISignal signal)
    {
        Type signalType = signal.GetType();

        foreach (ISubscription subscription in _subscriptions)
        {
            if (subscription.SubscribedSignal != signalType) continue;

            subscription.Invoke(signal);
        }
    }
}
