using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootingController : MonoBehaviour
{
    [SerializeField] private float rangeSeconds;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeBetweenShots;

    // Keep track of time.
    private float _time;

    private void FixedUpdate()
    {
        if (PlatformSpawner.round2 == true)
        {
            _time += Time.fixedDeltaTime;

            if (_time >= timeBetweenShots)
            {
                // Create a bullet.
                var bulletObject = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z - 2), Quaternion.identity);
                Debug.Log("BULLET CREATED");

                // Set it to expire on a timer.
                Destroy(bulletObject, rangeSeconds);

                _time = 0;
            }
        }
    }
}
