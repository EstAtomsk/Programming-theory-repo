using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float bound = 30f;

    public bool isMovementAllowed = true;

    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float turnSpeed = 50.0f;
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody playerRb;

    private bool isGrounded = true;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    private void Update()
    {
        StayInBounds();

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (isMovementAllowed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate((Vector3.forward * -1) * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
                isGrounded = false;
            }
        }
    }

    private void StayInBounds()
    {
        if (transform.position.x > bound)
        {
            transform.position = new Vector3(bound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -bound)
        {
            transform.position = new Vector3(-bound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bound);
        }
        if (transform.position.z < -bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -bound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
