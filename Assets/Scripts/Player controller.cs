using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private float speed = 10; 
    private Vector2 moveInput;
    private Rigidbody body; 
    [SerializeField] private float jumpHeight = 2;
    [SerializeField] private float jumpPeakTime = 0.5f;
    [SerializeField] private float jumpLandTime = 0.35f;
    [SerializeField] private Transform GroundCheckOrigin;
    [SerializeField] private Vector3 groundCheckBoxSize = new Vector3(0.8f, 0.05f, 0.08f);
    [SerializeField] private LayerMask groundMask;
    private bool jumpPressed;
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
        
        if (ScoreTracker.scoreTracker == 100)
        {
            speed = 13;
        }

        if (ScoreTracker.scoreTracker == 200)
        {
            speed = 17;
        }

        if (ScoreTracker.scoreTracker == 350)
        {
            speed = 19;
        }

        if (ScoreTracker.scoreTracker == 500)
        {
            speed = 21;
        }

        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
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

}
