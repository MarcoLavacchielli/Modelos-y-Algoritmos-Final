using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementeChar : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    public Animator myAnim;
    [SerializeField] private Charview view;
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

        if (moveDirection != Vector3.zero)
        {
            float rotationSpeed = 15f;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(newRotation);

            if (moveDirection.magnitude > 0.1f)
            {
                view.Isrunning(true);
            }
            else
            {
                view.Isrunning(false);
            }
        }
        else if (moveDirection == Vector3.zero)
        {
            view.Isrunning(false);
        }

        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);

        // Salto, aca podrias frenar la animacion de movimiento, y la de salto la haces en la funcion de salto
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
            view.Isjumping(true);
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
            view.Isjumping(false);
            //Aca terminaria la animacion de salto
        }
    }
}
