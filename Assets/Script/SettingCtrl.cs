    using UnityEngine;

    public class SettingCtrl : MonoBehaviour
        {
            public GameObject bagListPanel;   // BagList 패널
            public GameObject settingsPanel; // Settings 패널
            public GameObject mainPanel; // Main 패널

            // Bag 버튼 클릭 시 호출
            public void OnBagBtnClick()
                {
                    Debug.Log("Bag button clicked!"); // 버튼 클릭 확인

                    if (bagListPanel != null)
                        {
                            Debug.Log($"BagList Panel Reference: {bagListPanel.name}");
                            bagListPanel.SetActive(true);
                            mainPanel.SetActive(false);
                        }
                    else
                        {
                            Debug.LogError("BagList Panel is not assigned in the Inspector!");
                        }
                }
            public void OnSettingsBtnClick()
                {
                    Debug.Log("Settings button clicked!"); // 버튼 클릭 확인
                    if (settingsPanel != null)
                        {
                            Debug.Log($"Settings Panel Reference: {settingsPanel.name}");
                            settingsPanel.SetActive(true);
                            mainPanel.SetActive(false);
                        }
                    else
                        {
                            Debug.LogError("Settings Panel is not assigned in the Inspector!");
                        }
                }

        }
