using System.Linq.Expressions;
using UnityEngine;

public class PoweringUp : MonoBehaviour
{
    public float powerUpDuration = 5f;

    private void OnEnable()
    {
        ItemDestruction.PowerCollect += PowCollected;
    }

    private void OnDisable()
    {
        ItemDestruction.PowerCollect -= PowCollected;
    }

    private void PowCollected()
    {
        // Delegates effect to PlayerDeath for consistent power-up handling
        PlayerDeath player = GetComponent<PlayerDeath>();
        if (player != null)
        {
            player.ActivatePowerUp(powerUpDuration);
        }

        
    }
}
