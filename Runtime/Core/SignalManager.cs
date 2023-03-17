using System;

namespace Stinkysteak.SimplePubsub
{
    public static class SignalManager
    {
        public static void Subscribe<T>(Action<T> callback, bool oneTime) where T : ISignal
            => SignalManagerInstance.Instance.Subscribe(callback, oneTime);

        /// <summary>
        /// <b>Example Usage: </b><br/>
        /// | Unsubscribe(this, typeof(LogSignal)) ;
        /// </summary>
        /// <param name="signalType">Example: typeof(LogSignal))</param>
        public static void Unsubscribe(object listener, Type signalType) 
           => SignalManagerInstance.Instance.Unsubscribe(listener, signalType);

        public static void Publish(ISignal signal)
            => SignalManagerInstance.Instance.Publish(signal);
    }
}