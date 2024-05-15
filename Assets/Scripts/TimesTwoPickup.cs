using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesTwoPickup : MonoBehaviour
{
    public delegate void TimesTwoPickupTriggeredAction();
    public static event TimesTwoPickupTriggeredAction OnTimesTwoPickupTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        //trigger/broadcast event if another script is "listening"
        OnTimesTwoPickupTriggered?.Invoke();
        Destroy(gameObject);

    }
}
