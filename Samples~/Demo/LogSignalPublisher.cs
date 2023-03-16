using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace StinkySteak.SimplePubsub.Sample
{
    public class LogSignalPublisher : MonoBehaviour
    {
        [SerializeField] private string _message;

        public void Publish()
            => SignalManager.Instance.Publish(new LogSignal() { Message = _message });
    }

    [CustomEditor(typeof(LogSignalPublisher))]
    public class LogSignalPublisherEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LogSignalPublisher logSignalPublisher = (LogSignalPublisher)target;

            if (GUILayout.Button("Publish"))
            {
                if (!Application.isPlaying) return;
                
                logSignalPublisher.Publish();
            }
        }
    }
}