using UnityEngine;
using System.Collections;

public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    public float duration = 5f;

    // Virtual method that can be overridden by derived classes
    public virtual void ApplyPowerUp(GameObject player)
    {
        Debug.Log("PowerUp applied!");
    }

    protected IEnumerator PowerUpDuration(GameObject player)
    {
        yield return new WaitForSeconds(duration);
        RemovePowerUp(player);
        Destroy(gameObject); // Destroy power-up after use
    }

    // Abstract method to remove power-up, implemented in derived classes
    protected abstract void RemovePowerUp(GameObject player);
}
