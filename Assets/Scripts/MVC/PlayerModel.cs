using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    public Rigidbody rb;
    public Animator myAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}