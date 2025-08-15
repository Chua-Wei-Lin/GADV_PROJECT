using UnityEngine;

public class PlEnCollide : MonoBehaviour
{
    private PlayerDeath playerDeath;

    void Start()
    {
        playerDeath = GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Separates collision outcomes based on player's power state
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDeath enemy = collision.gameObject.GetComponent<EnemyDeath>();

            if (playerDeath.IsPoweredUp)
            {
                // Allows offensive action only when powered up
                if (enemy != null)
                    enemy.Die();
            }
            else
            {
                // Lose condition in non-powered state
                playerDeath.Die();
            }
        }
    }
}
