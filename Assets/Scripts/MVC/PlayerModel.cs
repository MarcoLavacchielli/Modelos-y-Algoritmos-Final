using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveDirection)
    {
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}