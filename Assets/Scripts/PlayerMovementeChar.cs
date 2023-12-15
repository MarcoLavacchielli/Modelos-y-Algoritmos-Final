using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementeChar : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    private Rigidbody rb;
    private int jumpsRemaining;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // Movimiento
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpsRemaining--;

        // Puedes reiniciar los saltos al tocar el suelo u otra condición
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reiniciar los saltos cuando toca el suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
