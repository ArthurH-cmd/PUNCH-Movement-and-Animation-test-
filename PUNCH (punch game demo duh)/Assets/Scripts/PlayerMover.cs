using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    [Header("Animation")]
    public Animator animator;

    bool isMoving;
    string currentKey = "";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.linearDamping = 0f; // No drag needed anymore
    }

    private void Update()
    {
        MyInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (moveDirection != Vector3.zero)
        {
            isMoving = true;
            Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
        }
        else
        {
            isMoving = false;
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
    }

    private void MyInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        if (Input.GetKey(KeyCode.W)) currentKey = "forward";
        else if (Input.GetKey(KeyCode.S)) currentKey = "backward";
        else if (Input.GetKey(KeyCode.A)) currentKey = "left";
        else if (Input.GetKey(KeyCode.D)) currentKey = "right";
        else if (Input.GetMouseButtonDown(1)) currentKey = "mouseRight";
        else currentKey = "";

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);

        if (isMoving)
        {
            animator.SetBool("isMoving", true);
        }
        else 
        { 
            animator.SetBool("isMoving", false);
        }
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        animator.SetFloat("Speed", flatVel.magnitude);
    }
}