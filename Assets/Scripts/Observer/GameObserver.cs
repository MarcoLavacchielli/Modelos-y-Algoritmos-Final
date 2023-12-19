using System;
using System.Collections;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
    public event Action<int> DamageChanged;
    public event Action<float> SpeedChanged;

    public void IncreaseDamage(int amount)
    {
        DamageChanged?.Invoke(amount);
        StartCoroutine(RestoreDamageAfterDelay(amount, 7f));
    }

    public void IncreaseSpeed(float amount)
    {
        SpeedChanged?.Invoke(amount);
        StartCoroutine(RestoreSpeedAfterDelay(amount, 7f));
    }

    private IEnumerator RestoreDamageAfterDelay(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        DecreaseDamage(amount);
    }

    private IEnumerator RestoreSpeedAfterDelay(float amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        DecreaseSpeed(amount);
    }

    public void DecreaseDamage(int amount)
    {
        DamageChanged?.Invoke(-amount);
    }

    public void DecreaseSpeed(float amount)
    {
        SpeedChanged?.Invoke(-amount);
    }
}