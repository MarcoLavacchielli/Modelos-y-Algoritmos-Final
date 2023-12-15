using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    private int jumpsRemaining;

    private void Start()
    {
        playerModel = GetComponent<PlayerModel>();
        playerView = GetComponent<PlayerView>();
        jumpsRemaining = playerModel.maxJumps;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        HandleMovement(moveDirection);
        HandleJump();
    }

    private void HandleMovement(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            float rotationSpeed = 15f;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion newRotation = Quaternion.Lerp(playerModel.rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            playerModel.rb.MoveRotation(newRotation);

            playerView.UpdateMovement(moveDirection);
        }
        else
        {
            playerView.UpdateMovement(Vector3.zero);
        }

        playerModel.rb.velocity = new Vector3(moveDirection.x * playerModel.speed, playerModel.rb.velocity.y, moveDirection.z * playerModel.speed);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
        }
        else
        {
            playerView.UpdateJump(false);
        }
    }

    private void Jump()
    {
        playerModel.rb.velocity = new Vector3(playerModel.rb.velocity.x, playerModel.jumpForce, playerModel.rb.velocity.z);
        jumpsRemaining--;
        playerView.UpdateJump(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpsRemaining = playerModel.maxJumps;
        }
    }
}