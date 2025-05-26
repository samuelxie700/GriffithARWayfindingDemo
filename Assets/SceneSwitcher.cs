using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // 拖入目标场景名称

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
