using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Button 컴포넌트를 사용하기 위해 필요

public class StartButton : MonoBehaviour
{
    public void StartClick(string sceneName)
    {
       SceneManager.LoadScene(sceneName);
    }
}
