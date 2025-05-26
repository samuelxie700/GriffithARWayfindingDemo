using UnityEngine;
using TMPro;
using System;

public class CountdownDisplay : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public int totalSeconds = 1800; // 30·ÖÖÓ = 1800Ãë

    private float timer;

    void Start()
    {
        timer = totalSeconds;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(timer);
            countdownText.text = "Class starts in " + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
        }
        else
        {
            countdownText.text = "Class has started";
        }
    }
}
