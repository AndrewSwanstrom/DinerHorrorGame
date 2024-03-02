using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;

    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 originalCameraPosition;

    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 10f;

    private float bobbingTimer = 0f;

    private float rotationX = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        originalCameraPosition = playerCamera.transform.localPosition;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
        BobCamera();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 moveVector = transform.TransformDirection(moveDirection);
            characterController.Move(moveVector * speed * Time.deltaTime);
        }
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);
    }

     void BobCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            float bobbingAmountThisFrame = Mathf.Sin(bobbingTimer) * bobbingAmount;

            Vector3 bobbingPosition = originalCameraPosition;
            bobbingPosition.y += bobbingAmountThisFrame;

            playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, bobbingPosition, Time.deltaTime * bobbingSpeed);

            bobbingTimer += Time.deltaTime * bobbingSpeed;
        }
        else
        {

            bobbingTimer = 0f;
            
            playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, originalCameraPosition, Time.deltaTime * bobbingSpeed);
        }
    }
}