using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    RigidBody rb;

    public float movementSpeed = 7;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<RigidBody>();
    }

    public void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput; //Movement input
        moveDirection = moveDirection + cameraObject.right * inputManager.horizonatalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        rb.velocity = moveVelocity;
    }

    public void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right  inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        Quaternion
    }
}
