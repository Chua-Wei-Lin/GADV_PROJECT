using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool IsPoweredUp { get; private set; }

    [Header("Powerup Settings")]
    public string normalTag = "Player";
    public string poweredTag = "BuffedPlayer";
    public RuntimeAnimatorController poweredSprite;
    public RuntimeAnimatorController normalSprite;

    private float powerUpTimer;
    private Animator animator;
    private Vector3 spawnPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        spawnPosition = transform.position; // store initial spawn

        gameObject.tag = normalTag;
        if (animator != null && normalSprite != null)
            animator.runtimeAnimatorController = normalSprite;
    }

    void Update()
    {
        if (IsPoweredUp)
        {
            powerUpTimer -= Time.deltaTime;
            if (powerUpTimer <= 0)
                EndPowerUp();
        }
    }

    public void ActivatePowerUp(float duration)
    {
        IsPoweredUp = true;
        powerUpTimer = duration;

        gameObject.tag = poweredTag;
        if (animator != null && poweredSprite != null)
            animator.runtimeAnimatorController = poweredSprite;
    }

    private void EndPowerUp()
    {
        IsPoweredUp = false;

        gameObject.tag = normalTag;
        if (animator != null && normalSprite != null)
            animator.runtimeAnimatorController = normalSprite;
    }

    public void Die()
    {
        animator.SetBool("Death", true);
        GetComponent<PlayerMovement>().enabled = false; // Stop movement
    }

    // Called from animation event at end of death animation
    public void Respawn()
    {
        transform.position = spawnPosition;
        animator.SetBool("Death", false);
        GetComponent<PlayerMovement>().enabled = true;
    }
}

