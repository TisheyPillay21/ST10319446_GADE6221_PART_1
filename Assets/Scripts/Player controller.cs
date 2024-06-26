using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private float saveSpeed;

    private Vector2 moveInput;
    private Rigidbody body; 
    [SerializeField] private float jumpHeight = 2;
    [SerializeField] private float jumpPeakTime = 0.5f;
    [SerializeField] private float jumpLandTime = 0.35f;
    [SerializeField] private Transform GroundCheckOrigin;
    [SerializeField] private Vector3 groundCheckBoxSize = new Vector3(0.8f, 0.05f, 0.08f);
    [SerializeField] private LayerMask groundMask;
    private bool jumpPressed;
    private bool keyPressed = false;

    public AudioSource hitCoin;
    public AudioSource hitPickup;
    public AudioSource hitBoss;
    public AudioSource boost;
    public AudioSource hitObstacle;

    public static bool speedBoost = false;
    public static float speedBoostTimer = 5;
    public static bool timesTwoBoost = false;
    public static float timesTwoBoostTimer = 10;

    public static float playerPosX;
    public static float playerPosZ;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = new Vector2( Input.GetAxis("Horizontal"), 0);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jumpPressed = true;
        //}
        if (speedBoost == false)
        {
            if (ScoreTracker.scoreTracker > 99)
            {
                speed = 13;
                saveSpeed = speed;
            }

            if (ScoreTracker.scoreTracker > 199)
            {
                speed = 16;
                saveSpeed = speed;
            }

            if (ScoreTracker.scoreTracker > 349)
            {
                speed = 18;
                saveSpeed = speed;
            }

            if (ScoreTracker.scoreTracker > 499)
            {
                speed = 20;
                saveSpeed = speed;
            }
        }

        if (speedBoost == true)
        {
            speed = 30;
            speedBoostTimer -= Time.deltaTime;

            if (speedBoostTimer < 1)
            {
                speedBoost = false;
                speed = 10;
                speedBoostTimer = 5;
            }
        }

        if (timesTwoBoost == true)
        {
            timesTwoBoostTimer -= Time.deltaTime;

            if (timesTwoBoostTimer < 1)
            {
                timesTwoBoost = false;
                timesTwoBoostTimer = 10;
            }
        }

        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        playerPosX = transform.position.x;
        playerPosZ = transform.position.z;

        if (PlatformSpawner.bossLevel == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += new Vector3(0, 0, 25 * Time.deltaTime);
            }
        }
    }

    private void OnEnable()
    {
        SpeedPickUp.OnSpeedPickupTriggered += OnSpeedPickupTriggeredHandler;
        TimesTwoPickup.OnTimesTwoPickupTriggered += OnTimesTwoPickupTriggeredHandler;
    }

    private void OnDisable()
    {
        SpeedPickUp.OnSpeedPickupTriggered -= OnSpeedPickupTriggeredHandler;
        TimesTwoPickup.OnTimesTwoPickupTriggered -= OnTimesTwoPickupTriggeredHandler;
    }

    private void OnSpeedPickupTriggeredHandler()
    {
        speedBoost = true;
    }

    private void OnTimesTwoPickupTriggeredHandler()
    {
        timesTwoBoost = true;
    }

    private void FixedUpdate()
    {
        //float verticalSpeed = body.velocity.y;
        //Vector3 verticalVelocity = Vector3.zero;

        //if (jumpPressed && IsOnGround())
        //{
        //    verticalVelocity = CalculateJumpVelocity() * Vector3.up;
        //    jumpPressed = false;
        //}
        //else
        //{
        //    verticalVelocity += Vector3.up * (verticalSpeed - CalculatedGravity() * Time.deltaTime);
        //}
        
        body.velocity = new Vector3(moveInput.x, 0, 0) * speed;
        //body.velocity += verticalVelocity;

    }
    private bool IsOnGround()
    {
        Collider[] colliders = Physics.OverlapBox(
            GroundCheckOrigin.position,
            groundCheckBoxSize * 0.5f,
            Quaternion.identity,
            groundMask
        );

        return colliders.Length > 0;
    }

    private float CalculateJumpVelocity()
    {
        return (2 * jumpHeight) / jumpPeakTime;
    }

    private float CalculatedGravity()
    {
        float time = body.velocity.y > 0 ? jumpPeakTime : jumpLandTime;
        return (2 * jumpHeight) / (time * time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            hitCoin.Play();
        }

        if (other.CompareTag("Pickup"))
        {
            hitPickup.Play();
        }

        if (other.CompareTag("Boss"))
        {
            hitBoss.Play();
        }

        if (other.CompareTag("Obstacle"))
        {
            hitObstacle.Play();
        }
    }
}
