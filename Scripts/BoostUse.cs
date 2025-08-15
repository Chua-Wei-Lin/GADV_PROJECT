using UnityEngine;

public class BoostUse : MonoBehaviour
{
    [SerializeField] private BoostFill boostfill;
    [SerializeField] private float boostSpeed = 200f;
    [SerializeField] private float normalSpeed = 100f;
    [SerializeField] private float depletionRate = 10f; // seconds per fuel unit
    [SerializeField] private PlayerMovement playerMovement;

    private float depletionTimer;


    // Using continuous key check allows player to hold boost button instead of toggling
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && boostfill.HasBoost())
        {
            playerMovement.speed = boostSpeed;

            // Accumulates time to control fuel depletion over intervals
            depletionTimer += Time.deltaTime;

            // Ensures depletion happens in discrete chunks rather than continuously draining small amounts
            while (depletionTimer >= depletionRate && boostfill.HasBoost())
            {
                boostfill.RemoveBoostUnit();
                depletionTimer -= depletionRate;
            }
        }
        else
        {
            playerMovement.speed = normalSpeed;
            depletionTimer = 0f;
        }
    }
}
