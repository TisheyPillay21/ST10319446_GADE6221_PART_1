using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    public delegate void SpeedPickupTriggeredAction();
    public static event SpeedPickupTriggeredAction OnSpeedPickupTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        //trigger/broadcast event if another script is "listening"
        OnSpeedPickupTriggered?.Invoke();
        Destroy(gameObject);

    }

    private void Update()
    {
        if (transform.position.z < (Playercontroller.playerPosZ - 10))
        {
            Destroy(gameObject);
        }
    }
}
