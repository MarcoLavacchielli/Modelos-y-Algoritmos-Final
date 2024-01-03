using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPointManager : MonoBehaviour
{

    private PlayerHealth playerHealth;

    [SerializeField] private LayerMask checkPoint;

    [SerializeField] private PlayerOriginator playerOriginator;

    private PlayerOriginator.PlayerMemento savedmemento;

    public bool failed = false;

    private void Awake()
    {
        this.savedmemento = playerOriginator.Save();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (failed == true)
        {
            playerOriginator.Restore(savedmemento);
            failed = false;
            playerHealth.TakeDamage(1);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (checkPoint == (checkPoint | (1 << other.gameObject.layer)))
        {
            this.savedmemento = playerOriginator.Save();
        }
    }
}
