using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public delegate void PlatformLeftAction(Platform platform);
    public static event PlatformLeftAction OnPlatformLeft;

    [SerializeField] private Transform connector;
    public Vector3 ConnectorPosition => connector.position;
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) 
            return;
        
        OnPlatformLeft?.Invoke(this);
    }
    
 
}
