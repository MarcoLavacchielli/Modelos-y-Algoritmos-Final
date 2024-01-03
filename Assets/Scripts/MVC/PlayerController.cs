using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask floor;
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
            Quaternion newRotation = Quaternion.Slerp(playerModel.rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            playerModel.rb.MoveRotation(newRotation);

            playerView.UpdateMovement(moveDirection);
        }
        else
        {
            playerView.UpdateMovement(Vector3.zero);
        }

        playerModel.Move(moveDirection);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            playerModel.Jump();
            jumpsRemaining--;
            playerView.UpdateJump(true);
        }
        else
        {
            playerView.UpdateJump(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (floor == (floor | (1 << collision.gameObject.layer)))
        {
            jumpsRemaining = playerModel.maxJumps;
        }
    }
}