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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDeath enemy = collision.gameObject.GetComponent<EnemyDeath>();

            if (playerDeath.IsPoweredUp)
            {
                if (enemy != null)
                    enemy.Die();
            }
            else
            {
                playerDeath.Die();
            }
        }
    }
}
