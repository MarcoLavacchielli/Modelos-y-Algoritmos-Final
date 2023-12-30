using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce = 10f;
    public float maxHeight = 0.1f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float jugadorPosY = other.transform.position.y;
            float trampolinPosY = transform.position.y;

            if (jugadorPosY > trampolinPosY + maxHeight)
            {
                Rigidbody jugadorRB = other.gameObject.GetComponent<Rigidbody>();

                jugadorRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
