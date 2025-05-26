using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // Ã¿ÃëÈÆ y ÖáĞı×ª 50 ¶È

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
