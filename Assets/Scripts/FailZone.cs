using UnityEngine;

public class FailZone : MonoBehaviour
{
    [SerializeField] private PlayerCheckPointManager playerCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("PlayerController"))
        {
            playerCheck.failed = true;
        }
    }
}
