using UnityEngine;

public class BoostFill : MonoBehaviour
{
    [SerializeField] private GameObject boostUnitPrefab; // prefab for 1 fuel unit
    [SerializeField] private Transform boostBarParent;   // container for boost units
    [SerializeField] private int maxUnits = 52;

    private int currentUnits = 0;

    private void OnEnable()
    {
        ItemDestruction.BoostCollect += AddBoostUnit;
    }

    private void OnDisable()
    {
        ItemDestruction.BoostCollect -= AddBoostUnit;
    }

    private void AddBoostUnit()
    {
        if (currentUnits >= maxUnits) return;

        GameObject newUnit = Instantiate(boostUnitPrefab, boostBarParent);
        float yOffset = currentUnits * 0.09f; // vertical spacing
        newUnit.transform.localPosition = new Vector3(0f, -2.235f + yOffset, 0f);

        currentUnits++;
    }

    public bool HasBoost()
    {
        return currentUnits > 0;
    }

    public void RemoveBoostUnit()
    {
        if (currentUnits <= 0) return;

        Transform lastUnit = boostBarParent.GetChild(boostBarParent.childCount - 1);
        Destroy(lastUnit.gameObject);
        currentUnits--;
    }
}
