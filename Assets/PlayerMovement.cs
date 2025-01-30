using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;   // Movement speed of the player
    public float jumpForce = 12f;  // Jump force applied to the Rigidbody

    [Header("Components")]
    public Animator animator;            // Reference to the Animator component
    public Rigidbody2D rb;               // Reference to the Rigidbody2D component
    public InputActionAsset inputAsset;  // Reference to InputActionAsset

    private InputAction moveAction;      // Movement input action
    private InputAction jumpAction;      // Jump input action
    private Vector2 movementInput;       // Movement input value

    private bool isGrounded;             // Check if the player is on the ground
    public Transform groundCheck;        // Empty GameObject to check ground
    public LayerMask groundLayer;        // LayerMask for the ground

    void Start()
    {
        // Input Actions setup
        moveAction = inputAsset.FindAction("Move");
        jumpAction = inputAsset.FindAction("Jump");
        moveAction.Enable();
        jumpAction.Enable();

        // Ensure components are set
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Read movement input
        movementInput = moveAction.ReadValue<Vector2>();

        // Check for jump input and if grounded
        if (jumpAction.triggered && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("jumping"); // Optional jump animation trigger
        }

        // Update Animator parameters
        animator.SetBool("running", movementInput.x != 0);
    }

    void FixedUpdate()
    {
        // Move the player horizontally
        rb.velocity = new Vector2(movementInput.x * moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
