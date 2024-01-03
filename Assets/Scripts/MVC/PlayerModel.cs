using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    public Rigidbody rb;

    [SerializeField] private GameObserver gameObserver;

    private int jumpsRemaining;

    private PlayerView playerView;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
        playerView = GetComponent<PlayerView>();
    }

    public void HandleMovement(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            float rotationSpeed = 15f;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(newRotation);
        }

        Move(moveDirection);

        playerView.UpdateMovement(moveDirection);
    }

    public void HandleJump(bool jumpInput)
    {
        if (jumpInput && jumpsRemaining > 0)
        {
            Jump();
            jumpsRemaining--;
            playerView.UpdateJump(jumpInput);
        }
        else
        {
            playerView.UpdateJump(false);
        }
    }

    private void Move(Vector3 moveDirection)
    {
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    public void ResetJumps()
    {
        jumpsRemaining = maxJumps;
    }

    private void OnEnable()
    {
        gameObserver.SpeedChanged += HandleVelocityChanged;
    }

    private void OnDisable()
    {
        gameObserver.SpeedChanged -= HandleVelocityChanged;
    }

    private void HandleVelocityChanged(float amount)
    {
        speed += amount;
    }
}