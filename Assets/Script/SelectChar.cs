using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public DataMgr.Character character;  // 'DataMgr.Character'로 명시적으로 지정
    private Animator anim;
    private SpriteRenderer sr;
    public SelectChar[] chars;  // 다른 캐릭터들

    void Awake()
    {
        // 초기화
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 현재 선택된 캐릭터와 일치하면 OnSelect(), 아니면 OffSelect()
        if (DataMgr.instance.selectedCharacter == character)
        {
            OnSelect();
        }
        else
        {
            OffSelect();
        }
    }

    private void OnMouseUpAsButton()
    {
        // 선택된 캐릭터 설정
        DataMgr.instance.selectedCharacter = character;

        // 선택된 캐릭터 OnSelect
        OnSelect();

        // 다른 캐릭터들 OffSelect()
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this)
            {
                chars[i].OffSelect();
            }
        }
    }

    void OnSelect()
    {
        // 선택된 캐릭터는 '걷기' 애니메이션 활성화
        anim.SetBool("run", true);
        sr.color = new Color(1f, 1f, 1f);  // 원래 색상으로 되돌리기
        Debug.Log("Selected Character: " + DataMgr.instance.selectedCharacter);  // 선택된 캐릭터 출력
    }

    void OffSelect()
    {
        // 선택되지 않은 캐릭터는 '걷기' 애니메이션 비활성화
        anim.SetBool("run", false);
        sr.color = new Color(0.5f, 0.5f, 0.5f);  // 비활성화 색상 (회색)
    }
}
