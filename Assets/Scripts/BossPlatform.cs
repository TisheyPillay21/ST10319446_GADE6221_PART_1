using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    public delegate void PlatformEnterAction(BossPlatform platform);
    public static event PlatformEnterAction OnPlatformEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        OnPlatformEnter?.Invoke(this);
    }
}
