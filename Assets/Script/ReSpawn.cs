using UnityEngine;
using System.Collections;

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

    void Start()
    {
        // 캐릭터 프리팹을 선택하여 생성
        player = Instantiate(charPreFabs[(int) DataMgr.instance.selectedCharacter]);
        Debug.Log("PlayScene Selected Character: " + DataMgr.instance.selectedCharacter);  // 선택된 캐릭터 출력

        // 캐릭터의 생성 위치를 현재 객체의 위치로 설정
        player.transform.position = transform.position;

        // 애니메이터 컴포넌트 가져오기
        anim = player.GetComponent<Animator>();

        // 애니메이션 재생 시작
        anim.SetBool("run", true); // 애니메이션 트리거

        // 이동 목표 설정 (현재 위치에서 우측으로 이동)
        targetPosition = player.transform.position + new Vector3(5f, 0f, 0f); // 3초간 우측으로 이동하도록 설정

        // 이동 시작
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            // 3초 동안 이동
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 목표 위치에 도달하면 이동 멈춤
            if (player.transform.position == targetPosition)
            {
                isMoving = false;

                // 애니메이션 멈추기
                anim.SetBool("run", false);
            }
        }

        // 마우스 클릭 시 애니메이션 재생
        if (Input.GetMouseButtonDown(0) && !isAnimating)
        {
            // 애니메이션을 2초 동안 실행하도록 설정
            StartCoroutine(PlayAnimationFor2Seconds());
        }

        // 애니메이션 타이머가 끝나면 애니메이션 멈추기
        if (isAnimating)
        {
            animationTimer -= Time.deltaTime;
            if (animationTimer <= 0f)
            {
                // 애니메이션이 끝났을 때
                anim.SetBool("run", false);
                isAnimating = false;
            }
        }
    }

    // 2초 동안 애니메이션 재생
    private IEnumerator PlayAnimationFor2Seconds()
    {
        isAnimating = true;
        animationTimer = 2f; // 2초 동안 애니메이션 재생

        // 애니메이션 시작 (예: 'run' 애니메이션)
        anim.SetBool("run", true);

        // 2초간 기다림
        yield return new WaitForSeconds(2f);

        // 애니메이션이 끝나면 'run' 상태를 false로 설정
        anim.SetBool("run", false);
    }
}
