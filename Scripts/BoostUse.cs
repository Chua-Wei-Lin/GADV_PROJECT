using UnityEngine;

public class BoostUse : MonoBehaviour
{
    [SerializeField] private BoostFill boostfill;
    [SerializeField] private float boostSpeed = 200f;
    [SerializeField] private float normalSpeed = 100f;
    [SerializeField] private float depletionRate = 1000000000f; // seconds per fuel unit
    [SerializeField] private PlayerMovement playerMovement;

    private float depletionTimer;



    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && boostfill.HasBoost())
        {
            playerMovement.speed = boostSpeed;

            depletionTimer += Time.deltaTime;

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
