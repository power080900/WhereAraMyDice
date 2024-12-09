using UnityEngine;

public class Backgroundctrl : MonoBehaviour
    {
        public GameObject mainPanel;   // MainPanel 참조
        public float moveSpeed = 5f;   // 배경 이동 속도
        public float resetPositionX = -17.6f;  // 리셋될 X 좌표
        public float startPositionX = 17.6f;   // 배경이 돌아갈 X 좌표
        public float moveDuration = 3f;        // 배경이 이동하는 시간 (초)

        private Vector3 targetPosition;  // 배경의 목표 위치
        private float moveStartTime;     // 이동 시작 시간
        private bool isMoving;           // 배경이 이동 중인지 여부

        void Start()
            {
                // 처음 시작할 때, 배경의 목표 위치는 현재 위치로 설정
                targetPosition = transform.position;
                isMoving = false;
            }

        void Update()
            {
                // 메인 패널이 활성화되어 있을 때만 배경을 이동
                if (mainPanel != null && mainPanel.activeSelf)
                    {
                        // 마우스 클릭을 감지
                        if (Input.GetMouseButtonDown(0) && !isMoving)  // 0은 왼쪽 마우스 클릭
                            {
                                // 이동을 시작하고, 이동 시작 시간을 기록
                                isMoving = true;
                                moveStartTime = Time.time;

                                // 배경을 왼쪽으로 이동할 목표 위치를 설정
                                targetPosition = new Vector3(transform.position.x - 17.6f, transform.position.y, transform.position.z);
                            }

                    // 배경이 이동 중이라면
                    if (isMoving)
                        {
                            // 배경을 부드럽게 이동
                            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                            // 이동 시간이 설정된 시간(duration)을 초과하면 멈춤
                            if (Time.time - moveStartTime >= moveDuration)
                                {
                                    isMoving = false;  // 이동을 멈춤
                                }
                        }

                    // 배경의 X 좌표가 -17.6에 도달했을 때
                    if (transform.position.x <= resetPositionX)
                        {
                            // 배경의 X 좌표를 17.6으로 설정하여 리셋
                            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
                        }
                    }
            }
    }
