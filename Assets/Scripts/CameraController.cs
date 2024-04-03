using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform cameraTarget;
   [SerializeField] private float smoothness = 0.5f; 

   private void LateUpdate()
   {
      transform.position = Vector3.Slerp(transform.position, cameraTarget.position,smoothness); 
   }
}
