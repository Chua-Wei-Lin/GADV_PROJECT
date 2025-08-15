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
        PlayerDeath player = GetComponent<PlayerDeath>();
        if (player != null)
        {
            player.ActivatePowerUp(powerUpDuration);
        }

        
    }
}
