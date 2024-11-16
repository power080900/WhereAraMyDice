using UnityEngine;

public enum ItemType { Weapon, Armor, ConsumableWeapon, MagicWeapon, Consumable }
public enum ItemRarity { Normal, Rare, Epic, Unique, Legendary }
public enum DiceType { D4 = 4, D6 = 6, D8 = 8, D12 = 12, D20 = 20 }

[System.Serializable]
public class Item
{
    public string itemName;       // 아이템 이름
    public ItemType itemType;     // 아이템 타입
    public ItemRarity itemRarity; // 아이템 등급
    public DiceType diceType;     // 주사위 종류
    public int[] diceValues;      // 주사위 눈 값

    public Item(string name, ItemType type, ItemRarity rarity, DiceType dice, int[] values)
    {
        itemName = name;
        itemType = type;
        itemRarity = rarity;
        diceType = dice;
        diceValues = values;
    }

    // 주사위 굴리는 함수
    public int RollDice()
    {
        int randomIndex = Random.Range(0, diceValues.Length);
        return diceValues[randomIndex];
    }
}
