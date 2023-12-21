using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    public float alturaPermitida = 0.1f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float jugadorPosY = other.transform.position.y;
            float trampolinPosY = transform.position.y;

            if (jugadorPosY > trampolinPosY + alturaPermitida)
            {
                Rigidbody jugadorRB = other.gameObject.GetComponent<Rigidbody>();

                jugadorRB.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }
        }
    }
}
