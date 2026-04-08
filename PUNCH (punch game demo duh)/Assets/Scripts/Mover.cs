using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float mouseSensitivity = 2f;

    private Vector3 moveDirection;
    private float rotationY = 0f;
    private float rotationX = 0f;


    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleMouseLook();
        Debug.Log("i am running");
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY += mouseX * mouseSensitivity;
        rotationX += mouseY * mouseSensitivity;

        rotationX = Math.Clamp(rotationX, -20, 20);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        

    }
}
