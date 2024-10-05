using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 7;
    [SerializeField] float gravity = -10;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;
    private Vector3 velocity;

    private PlayerInputManager inputManager;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckJumpAndGravity();
    }

    void CheckMovement()
    {
        Vector2 moveValue = inputManager.movementValue;
        Vector3 targetDirection = new Vector3(moveValue.x, 0, moveValue.y);
        // controller.Move(moveValue * speed * Time.deltaTime);
        controller.Move(targetDirection * speed * Time.deltaTime);
    }

    void CheckJumpAndGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .2f, groundLayer);
        
        bool isJumping = inputManager.didJump;
        if (inputManager.didJump)
        {
            inputManager.didJump = false;
        }

        if (isGrounded)
        {
            if (isJumping) {
                velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }
}