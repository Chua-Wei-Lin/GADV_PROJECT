using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    private Vector3 spawnPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        spawnPosition = transform.position;
    }

    public void Die()
    {
        animator.SetBool("Death", true);
        GetComponent<EnemyPatrol>().enabled = false;
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
        animator.SetBool("Death", false);
        GetComponent<EnemyPatrol>().enabled = true;

        EnemyPatrol patrol = GetComponent<EnemyPatrol>();
        if (patrol != null)
        {
            patrol.ResetPatrol();
        }
    }
}
