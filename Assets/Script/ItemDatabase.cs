using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database", menuName = "Items/Create Item Database")]
public class ItemDatabase : ScriptableObject
    {
        public List<ItemData> items;
    }
