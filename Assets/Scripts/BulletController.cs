using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float bulletSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity -= new Vector3(transform.position.x, transform.position.y, transform.position.z - 5) * bulletSpeed * Time.fixedDeltaTime;
    }
}
