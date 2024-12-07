using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // 패널 오브젝트
    public GameObject mainPanel; // 메인 패널 오브젝트

    // 패널 닫기 함수
    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // 패널 비활성화
            mainPanel.SetActive(true); // 메인 패널 활성화
        }
    }
}
