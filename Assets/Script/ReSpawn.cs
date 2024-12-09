using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReSpawn : MonoBehaviour
{
    public GameObject mainPanel;   // MainPanel 참조
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

        // 초기 위치 및 크기 설정
        player.transform.position = transform.position;

        // 생성된 캐릭터를 MainPanel의 하위로 설정
        if (mainPanel != null)
        {
            player.transform.SetParent(mainPanel.transform, false);

            // 위치 수정
            player.transform.localPosition = new Vector3(-1120f, -380f, 0f); // 원하는 위치로 조정
            Debug.Log($"Player Local Position set to: {player.transform.localPosition}");

            // 크기 수정
            player.transform.localScale = new Vector3(300f, 300f, 0); // 원하는 크기로 조정
            Debug.Log($"Player Local Scale set to: {player.transform.localScale}");
        }

        anim = player.GetComponent<Animator>();
        anim.SetBool("run", true);
        targetPosition = player.transform.position + new Vector3(5f, 0f, 0f);
        isMoving = true;
    }

    void Update()
    {
        // MainPanel이 비활성화 상태라면 동작하지 않음
        if (mainPanel == null || !mainPanel.activeSelf)
        {
            return;
        }

        if (!mainPanel.activeSelf)
        {
            player.SetActive(false);
            return;
        }
        else
        {
            player.SetActive(true); // MainPanel 활성화 시 player도 활성화
        }

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

    private IEnumerator PlayAnimationFor2Seconds()
    {
        isAnimating = true;
        animationTimer = 2f;
        anim.SetBool("run", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("run", false);
    }
}
