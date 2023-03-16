using UnityEngine;

namespace StinkySteak.SimplePubsub.Sample
{
    public class LogSignalSubscriber : MonoBehaviour
    {
        private void Start()
        {
            SignalManager.Instance.Subscribe<LogSignal>(OnLogged);
        }
        private void OnLogged(LogSignal signal)
        {
            print($"Log: {signal}");
        }
    }
}