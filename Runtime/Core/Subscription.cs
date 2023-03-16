using System;

/// <summary>
/// Relation between Listener and Signal Type
/// </summary>
/// <typeparam name="T"></typeparam>
public class Subscription<T>  : ISubscription where T : ISignal 
{
    private readonly Action<T> _callback;

    private readonly Type _subscribedSignal;
    public Type SubscribedSignal => _subscribedSignal;

    public void Invoke(ISignal signal)
        => _callback?.Invoke((T)signal);

    public Subscription(Action<T> callback)
    {
        _subscribedSignal = typeof(T);
        _callback = callback;
    }
}
