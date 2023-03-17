public interface ISubscription
{
    bool OneTime { get; }
    object Listener { get; }
    void Invoke(ISignal signal);
    System.Type SubscribedSignal { get; }
}
