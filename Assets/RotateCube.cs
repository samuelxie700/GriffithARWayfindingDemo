using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // ÿ���� y ����ת 50 ��

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
