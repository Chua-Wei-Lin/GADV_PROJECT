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
        animator = GetComponent<Animator>(); // Cached reference to avoid repeated GetComponent calls
        spawnPosition = transform.position; // store initial spawn
        // Sets default state
        gameObject.tag = normalTag;
        if (animator != null && normalSprite != null)
            animator.runtimeAnimatorController = normalSprite;
    }

    void Update()
    {
        // Timer-based expiration ensures power-ups don't last indefinitely
        if (IsPoweredUp)
        {
            powerUpTimer -= Time.deltaTime;
            if (powerUpTimer <= 0)
                EndPowerUp();
        }
    }

    public void ActivatePowerUp(float duration)
    {
        // Encapsulates activation to ensure all related states update consistently
        IsPoweredUp = true;
        powerUpTimer = duration;

        gameObject.tag = poweredTag;
        if (animator != null && poweredSprite != null)
            animator.runtimeAnimatorController = poweredSprite;
    }

    private void EndPowerUp()
    {
        // Restores original collision rules and visuals
        IsPoweredUp = false;

        gameObject.tag = normalTag;
        if (animator != null && normalSprite != null)
            animator.runtimeAnimatorController = normalSprite;
    }

    public void Die()
    {
        // Signals death visually and stops player control to avoid inconsistent state
        animator.SetBool("Death", true);
        GetComponent<PlayerMovement>().enabled = false;
    }
    // Triggered via animation event so timing syncs perfectly with visuals
    public void Respawn()
    {
        transform.position = spawnPosition;
        animator.SetBool("Death", false);
        GetComponent<PlayerMovement>().enabled = true;
    }
}

