using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // ����Ŀ�곡������

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
