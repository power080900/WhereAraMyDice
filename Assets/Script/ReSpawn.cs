using UnityEngine;
using System.Collections; // 코루틴에 필요한 네임스페이스만 포함
using System.Collections.Generic; // 딕셔너리 등 제네릭 컬렉션에 필요

public class ReSpawn : MonoBehaviour
{
    public GameObject[] charPreFabs;  // 캐릭터 프리팹들
    private GameObject player;  // 플레이어 캐릭터
    private Animator anim;  // 캐릭터 애니메이터
    private float moveSpeed = 2f;     // 이동 속도 (우측으로)
    private Vector3 targetPosition;   // 이동 목표 위치
    private bool isMoving = false;    // 이동 상태
    private bool isAnimating = false; // 애니메이션 상태
    private float animationTimer = 0f; // 애니메이션 타이머

    // 캐릭터별 기본 아이템 데이터
    private Dictionary<DataMgr.Character, List<string>> characterItems;

    void Start()
    {
        InitializeCharacterItems();
        player = Instantiate(charPreFabs[(int)DataMgr.instance.selectedCharacter]);
        Debug.Log("PlayScene Selected Character: " + DataMgr.instance.selectedCharacter);

        if (characterItems.TryGetValue(DataMgr.instance.selectedCharacter, out List<string> items))
        {
            Debug.Log("Items for " + DataMgr.instance.selectedCharacter + ": " + string.Join(", ", items));
        }

        player.transform.position = transform.position;
        anim = player.GetComponent<Animator>();
        anim.SetBool("run", true);
        targetPosition = player.transform.position + new Vector3(5f, 0f, 0f);
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (player.transform.position == targetPosition)
            {
                isMoving = false;
                anim.SetBool("run", false);
            }
        }

        if (Input.GetMouseButtonDown(0) && !isAnimating)
        {
            StartCoroutine(PlayAnimationFor2Seconds());
        }

        if (isAnimating)
        {
            animationTimer -= Time.deltaTime;
            if (animationTimer <= 0f)
            {
                anim.SetBool("run", false);
                isAnimating = false;
            }
        }
    }

    private void InitializeCharacterItems()
    {
        characterItems = new Dictionary<DataMgr.Character, List<string>>
        {
            { DataMgr.Character.Knight, new List<string> { "Rusty Greatsword", "Esquire's Armor" } },
            { DataMgr.Character.Archer, new List<string> { "Bow", "Old Leather Armor" } },
            { DataMgr.Character.Magician, new List<string> { "Novice Wizard's Staff", "Novice Wizard's Robe" } }
        };
    }

    private System.Collections.IEnumerator PlayAnimationFor2Seconds()
    {
        isAnimating = true;
        animationTimer = 2f;
        anim.SetBool("run", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("run", false);
    }
}
