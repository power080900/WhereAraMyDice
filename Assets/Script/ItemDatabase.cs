using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Create Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> items;
}