using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    public float alturaPermitida = 0.1f; // Ajusta este valor seg�n la altura del trampol�n

    private void OnCollisionEnter(Collision other)
    {
        // Verificar si el objeto que colision� es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Obtener las posiciones del jugador y del trampol�n en el eje Y
            float jugadorPosY = other.transform.position.y;
            float trampolinPosY = transform.position.y;

            // Verificar si el jugador est� suficientemente arriba del trampol�n
            if (jugadorPosY > trampolinPosY + alturaPermitida)
            {
                // Obtener el componente Rigidbody del jugador
                Rigidbody jugadorRB = other.gameObject.GetComponent<Rigidbody>();

                // Aplicar una fuerza hacia arriba al jugador
                jugadorRB.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }
        }
    }
}
