using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/**
* ThirdPersonMovement class for handling player movement, animations and gravity
*/
public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]private CharacterController controller;
    [SerializeField]private Transform cam;
    [SerializeField]private float gravity = -9.81f;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundDistance = 0.4f;
    [SerializeField]private LayerMask groundMask;

    private bool isGrounded;
    private Vector3 velocity;

    [Header("Basics")]
    public bool canMove = true;

    [Header("Camera Turning")]
    [SerializeField]private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [Header("Controllers")]
    [SerializeField]private PlayerStats playerStats;
    [SerializeField]private PlayerHealthManager playerHealthManager;
    [SerializeField]private Animator animator;

    [Header("Sprinting")]
    private bool isSprinting = false;
    [SerializeField]private float sprintSpeedMultiplier = 2f;

    /**
    * This method is called every frame to update the character's movement and animation.
    * If the player is not alive, no movement will be performed.
    * Gravity is applied to the character and the character is moved based on player input.
    * Sprinting speed and animation are also applied if the player presses the space key.
    */
    void Update()
    {
        if (playerHealthManager.Alive)
        {
            // Gravity
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            // Check for space key input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSprinting = true;
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                isSprinting = false;
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }

            // Walking
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f && canMove)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                float moveSpeed = playerStats.PlayerMoveSpeed;

                // Apply sprinting speed and animation
                if (isSprinting)
                {
                    moveSpeed *= sprintSpeedMultiplier;
                }

                controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

                // Set walking animation
                if (!isSprinting)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isRunning", false);
                    }
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isRunning", false);
                }
            }
        }
}


