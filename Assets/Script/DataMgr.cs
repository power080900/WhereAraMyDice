using UnityEngine;

public class DataMgr : MonoBehaviour
{
    public enum Character
    {
        Knight,
        Archer, // Magician 추가 가능
    }

    public static DataMgr instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            return;

        DontDestroyOnLoad(gameObject);  // 씬 전환 시 오브젝트 유지
    }

    public Character selectedCharacter;  // 선택된 캐릭터를 저장
}
