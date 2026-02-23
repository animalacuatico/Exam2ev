using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5, sprintSpeed = 10f, jumpForce = 8f;
    public float gravity = -9.81f, mouseSensitivity = 2f;
    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public bool isMobile = false;
    Vector2 moveDir = Vector2.zero;
    bool isGrounded;
    float xRotation = 0f, yVelocity = 0f;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (!isMobile)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void Update()
    {
        if (!isMobile)
        {
            float mx = Input.GetAxis("Mouse X") * mouseSensitivity;
            float my = Input.GetAxis("Mouse Y") * mouseSensitivity;
            xRotation -= my;
            xRotation = Mathf.Clamp(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mx);
            moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetButtonDown("Jump") && isGrounded) yVelocity = jumpForce;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 delta = Input.GetTouch(0).deltaPosition;
            xRotation -= delta.y * 0.1f;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * delta.x * 0.1f);
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Vector3 move = transform.right * moveDir.x + transform.forward * moveDir.y;
        float speed = (!isMobile && Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed : playerSpeed;
        move *= speed;
        if (isGrounded && yVelocity < 0) yVelocity = -2f;
        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity;
        characterController.Move(move * Time.deltaTime);
    }
    public void SetMoveDir (Vector2 dir)
    {
        moveDir = dir;
    }
    public void MobileJump()
    {
        if (isGrounded)
        {
            yVelocity = jumpForce;
        }
    }
    public void SetSprint (bool sprint)
    {

    }
}
