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
            CancelInvoke("HidePopup");     // ȷ��������ǰ��ǰһ�εĶ�ʱ���ظ���
            Invoke("HidePopup", 5f);       // 5 �������
        }
    }

    void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
