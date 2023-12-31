using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float angle = 30.0f;

    [SerializeField] private float yOffset = 0.0f;

    private void Update()
    {
        if (playerTransform == null)
        {
            Debug.Log("Player reference missing");
            return;
        }

        Quaternion originalRotation = transform.rotation;

        Vector3 offset = Quaternion.Euler(angle, 0, 0) * Vector3.back * distance;
        offset.y += yOffset;
        transform.position = playerTransform.position + offset;

        transform.rotation = originalRotation;
    }
}