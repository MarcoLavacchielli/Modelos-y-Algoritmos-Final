using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Charview view;
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    private void Awake()
    {
        view = GetComponent<Charview>();
        rb = GetComponent<Rigidbody>();
    }

    public void RotatePlayer(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            float rotationSpeed = 15f;
            Quaternion targetRotation = Quaternion.LookRotation(move);
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(newRotation);

            if (move.magnitude > 0.1f)
            {
                view.Isrunning(true);
            }
            else
            {
                view.Isrunning(false);
            }
        }
        else if (move == Vector3.zero)
        {
            view.Isrunning(false);
        }
    }
}
