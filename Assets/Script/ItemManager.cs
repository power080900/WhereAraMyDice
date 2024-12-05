using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemDatabase itemDatabase;

    void Start()
    {
        foreach (var itemData in itemDatabase.items)
        {
            Debug.Log($"아이템 이름: {itemData.itemName}");
            Debug.Log($"희귀도: {itemData.rarity}");
        }
    }
}
