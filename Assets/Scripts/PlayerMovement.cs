using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private bool canJump = true;
    [SerializeField]
    private bool isGrounded = true;
    [SerializeField]
    private float movementSpeed = 5.0f;

    private GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        PlayerJumpHandle();
        PlayerMovementHandle();
    }
    private void PlayerMovementHandle()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        rb.velocity = new Vector3(movement.x * movementSpeed, rb.velocity.y, movement.z * movementSpeed);
    }
    private void PlayerJumpHandle()
    {
        if (canJump && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGroundCollisionEnter();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGroundCollisionExit();
        }
    }
    public void OnGroundCollisionEnter()
    {
        isGrounded = true;
        canJump = true;
    }
    public void OnGroundCollisionExit()
    {
        isGrounded = false;
    }
}
