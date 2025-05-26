using UnityEngine;
using TMPro;

public class CollisionTimerPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text popupText;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        popupPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float timeUsed = Time.time - startTime;
            popupText.text = $"You reached the target in {timeUsed:F2} seconds.";

            popupPanel.SetActive(true);
            CancelInvoke("HidePopup");     // 确保不会提前被前一次的定时隐藏干扰
            Invoke("HidePopup", 5f);       // 5 秒后隐藏
        }
    }

    void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
