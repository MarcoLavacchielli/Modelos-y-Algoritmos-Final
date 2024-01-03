using UnityEngine;

public class EnChaseRt : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);

        Quaternion targetRotation = Quaternion.LookRotation(targetOrientation);

        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
    }
}
