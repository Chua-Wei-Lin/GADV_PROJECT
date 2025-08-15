using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform spawnerParent;
   
    void Start()
    {
        Spawning();
    }

    void Spawning()
    {
        foreach (Transform child in spawnerParent.transform)
        {
            Instantiate(itemToSpawn, child.position, child.rotation);
        }
    }
    
    void Update()
    {
        
    }
}
