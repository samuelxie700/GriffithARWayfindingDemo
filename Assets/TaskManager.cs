using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public float timer = 10f;                        // Countdown timer duration
    public GameObject targetCube;                    // Target cube to reach
    public TextMeshProUGUI messageText;              // UI text to show messages

    private bool isFinished = false;                 // Has the task ended?

    void Update()
    {
        if (isFinished) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            messageText.text = "Too bad! Time is up.";
            isFinished = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFinished) return;

        if (other.gameObject == targetCube)
        {
            messageText.text = "Congratulations! You reached the target.";
            isFinished = true;
        }
    }
}

