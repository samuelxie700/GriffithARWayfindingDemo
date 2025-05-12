using UnityEngine;

public class ColorBlink : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.red;
    public float blinkInterval = 0.5f; // …¡À∏º‰∏Ù ±º‰£®√Î£©

    private Renderer rend;
    private bool toggle = false;
    private float timer = 0f;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= blinkInterval)
        {
            toggle = !toggle;
            rend.material.color = toggle ? color1 : color2;
            timer = 0f;
        }
    }
}
