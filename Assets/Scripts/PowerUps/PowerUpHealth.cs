using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerHealth>().Health(1);

        AudioManager.Instance.PlaySFX(2);

        Destroy(gameObject);
    }
}
