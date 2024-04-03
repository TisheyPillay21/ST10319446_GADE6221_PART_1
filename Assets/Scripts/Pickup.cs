using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using random = UnityEngine.Random;

public class Pickup : MonoBehaviour
{
   public delegate void PickupTriggeredAction();
   public static event PickupTriggeredAction OnPickupTriggered;

   private void OnTriggerEnter(Collider other)
   {
      if (!other.CompareTag("Player"))
         return;

        //trigger/broadcast event if another script is "listening"
        OnPickupTriggered?.Invoke();
        Destroy(gameObject);
        
   }
}
