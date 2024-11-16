using UnityEngine;

public class GameSelectionManager : MonoBehaviour
{
    public void SelectCharacter(int characterIndex)
    {
        DataMgr.Character character = (DataMgr.Character)characterIndex;
        DataMgr.instance.selectedCharacter = character;
        Debug.Log($"캐릭터 선택: {character}");
    }

    public void SelectItemBundle(string bundleName)
    {
        DataMgr.instance.selectedItemBundle = bundleName;
        Debug.Log($"아이템 묶음 선택: {bundleName}");
    }

    public void StartGame()
    {
        Debug.Log($"게임 시작 - 선택된 캐릭터: {DataMgr.instance.selectedCharacter}, 선택된 아이템 묶음: {DataMgr.instance.selectedItemBundle}");
        // 게임 시작 로직 추가
    }
}
