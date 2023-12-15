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
    private bool isWalking; //booleano para saber si me muevo
    private bool isJumping; //booleano para saber si salto

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

        if (moveDirection != Vector3.zero) //Aca se mueve, aca podes meter la animacion y eso
        {
            isWalking = true;
            //Debug.Log("me muevo");
        }
        else  // Aca no
        {
            isWalking = false;
            //Debug.Log("me quedo quieto");
        }

        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);

        // Salto, aca podrias frenar la animacion de movimiento, y la de salto la haces en la funcion de salto
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
            isJumping = true;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpsRemaining--;

        // Puedes reiniciar los saltos al tocar el suelo u otra condición, fijate si podes agregar la animacion por aca
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reiniciar los saltos cuando toca el suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpsRemaining = maxJumps;
            isJumping = false;
            //Aca terminaria la animacion de salto
        }
    }
}
