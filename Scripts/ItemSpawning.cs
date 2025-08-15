using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform spawnerParent;
   
    void Start()
    {
        // Pre-populates scene with items immediately at game start
        Spawning();
    }

    void Spawning()
    {
        // Iterates over child transforms to use pre-placed positions without hardcoding coordinates
        foreach (Transform child in spawnerParent.transform)
        {
            Instantiate(itemToSpawn, child.position, child.rotation);
        }
    }
}
