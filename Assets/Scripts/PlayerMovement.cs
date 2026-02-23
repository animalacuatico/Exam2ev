using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5, gravForce = -9f;
    public CharacterController characterController;
    public bool isMobile = false;
    private Vector3 moveDir;

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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        moveDir = new Vector3 (x * playerSpeed, gravForce, z * playerSpeed);
        characterController.Move(moveDir * Time.deltaTime);
    }
}
