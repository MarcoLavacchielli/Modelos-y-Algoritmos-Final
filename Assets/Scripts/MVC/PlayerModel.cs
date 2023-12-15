using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int life = 100;

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

    public PlayerLifeMemento CreateMemento()
    {
        return new PlayerLifeMemento(life);
    }

    public void RestoreFromMemento(PlayerLifeMemento memento)
    {
        life = memento.Life;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log("Player took damage. Current life: " + life);
    }

    public void RecoverLife(int recoveryAmount)
    {
        life += recoveryAmount;
        Debug.Log("Player recovered life. Current life: " + life);
    }
}