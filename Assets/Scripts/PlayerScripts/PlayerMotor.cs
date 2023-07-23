using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool crouching = false;
    private bool lerpCrouch = false;
    private float crouchTimer = 0f;
    private bool sprinting = false;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float walkSpeed = 5f;
    private float speed = 5f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch) {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;

            if (crouching) {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            } else {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }

            if (p > 1) {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }
    //Receive inputs from input manger script and apply them to character controller
    public void ProcessMove(Vector2 input) {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump() {
        if(isGrounded) {
            if(crouching) {
                Crouch();
            } else {
                playerVelocity.y = Mathf.Sqrt(jumpSpeed * -3f * gravity);
            }
        }
    }

    public void Crouch () {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    
    //Todo: Disable sprint when stopping
    public void Sprint () {
        sprinting = !sprinting;
        if(sprinting)
            speed = sprintSpeed;
        else
            speed = walkSpeed;
    }
}
