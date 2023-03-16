using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubscription
{
    void Invoke(ISignal signal);
    System.Type SubscribedSignal { get; }
}
