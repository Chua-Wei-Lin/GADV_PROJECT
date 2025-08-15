using UnityEngine;

public class BoostFill : MonoBehaviour
{
    [SerializeField] private GameObject boostUnitPrefab; // prefab for 1 fuel unit
    [SerializeField] private Transform boostBarParent;   // container for boost units
    [SerializeField] private int maxUnits = 52;

    private int currentUnits = 0;

    private void OnEnable()
    {
        // Subscribing here ensures we only listen for events while active, avoiding unnecessary calls and memory leaks
        ItemDestruction.BoostCollect += AddBoostUnit;
    }

    private void OnDisable()
    {
        // Unsubscribing prevents lingering references and accidental calls after object is disabled
        ItemDestruction.BoostCollect -= AddBoostUnit;
    }

    private void AddBoostUnit()
    {
        if (currentUnits >= maxUnits) return;

        // Instantiate dynamically so the UI reflects game state changes in real time
        GameObject newUnit = Instantiate(boostUnitPrefab, boostBarParent);
        float yOffset = currentUnits * 0.09f; // Maintains even spacing regardless of how many units are present
        newUnit.transform.localPosition = new Vector3(0f, -2.235f + yOffset, 0f);

        currentUnits++;
    }

    public bool HasBoost()
    {
        // Encapsulates boost availability logic so other scripts don’t depend on internal variable details
        return currentUnits > 0;
    }

    public void RemoveBoostUnit()
    {
        // Prevents removing when empty to avoid null references and logic errors
        if (currentUnits <= 0) return;

        // Targets last-added unit for removal, maintaining a LIFO depletion pattern
        Transform lastUnit = boostBarParent.GetChild(boostBarParent.childCount - 1);
        Destroy(lastUnit.gameObject);
        currentUnits--;
    }
}
