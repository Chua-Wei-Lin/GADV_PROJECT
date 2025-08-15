using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    private Vector3 spawnPosition;

    void Start()
    {
        // Animator reference stored once to avoid repeated GetComponent calls
        animator = GetComponent<Animator>();
        // Spawn position cached for instant respawn without searching or recalculating
        spawnPosition = transform.position;
    }

    public void Die()
    {
        // Animation flag signals visual state change
        animator.SetBool("Death", true);
        // Patrol disabled so AI doesn’t move while dead
        GetComponent<EnemyPatrol>().enabled = false;
    }

    public void Respawn()
    {
        // Restores position and state instantly without reloading object
        transform.position = spawnPosition;
        animator.SetBool("Death", false);
        GetComponent<EnemyPatrol>().enabled = true;

        // Resets patrol logic to avoid desync with waypoints after death
        EnemyPatrol patrol = GetComponent<EnemyPatrol>();
        if (patrol != null)
        {
            patrol.ResetPatrol();
        }
    }
}
