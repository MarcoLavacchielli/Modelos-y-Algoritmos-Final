using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask floor;
    private PlayerModel playerModel;

    private void Start()
    {
        playerModel = GetComponent<PlayerModel>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        playerModel.HandleMovement(moveDirection);
        playerModel.HandleJump(Input.GetKeyDown(KeyCode.Space));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (floor == (floor | (1 << collision.gameObject.layer)))
        {
            playerModel.ResetJumps();
        }
    }
}