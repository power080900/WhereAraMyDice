using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create New Item")]
public class ItemData : ScriptableObject
    {
        public string itemName;
        public Rarity rarity;
        public ItemType type;
        public DiceType dice;
        public List<int> diceValues = new List<int>(); // 주사위 값 리스트
        public string description;

        public Sprite itemImage; // 아이템 이미지

        // 주사위 값 길이 제한 메서드
        public void ValidateDiceValues()
            {
                int requiredCount = GetDiceValueCount(dice);

                // 리스트가 초과되면 자르기
                while (diceValues.Count > requiredCount)
                    {
                        diceValues.RemoveAt(diceValues.Count - 1);
                    }

                // 리스트가 부족하면 채우기
                while (diceValues.Count < requiredCount)
                    {
                        diceValues.Add(1); // 기본값으로 1 추가
                    }
            }

        // DiceType에 따라 필요한 주사위 값 개수 반환
        private int GetDiceValueCount(DiceType diceType)
            {
                switch (diceType)
                    {
                        case DiceType.D4: return 4;
                        case DiceType.D6: return 6;
                        case DiceType.D8: return 8;
                        case DiceType.D12: return 12;
                        case DiceType.D20: return 20;
                        default: return 0;
                    }
            }
    }

public enum Rarity { Common, Uncommon, Rare, Legendary, Epic, Mythic }
public enum ItemType { Weapon, Armor, HealthRecovery, SingleUseAttack }
public enum DiceType { D4, D6, D8, D12, D20 }
