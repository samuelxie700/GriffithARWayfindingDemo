using System.Collections;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    private Renderer rend1;
    private Renderer rend2;

    private void Start()
    {
        rend1 = cube1.GetComponent<Renderer>();
        rend2 = cube2.GetComponent<Renderer>();
        StartCoroutine(SwitchLights());
    }

    IEnumerator SwitchLights()
    {
        while (true)
        {
            // Cube1 �̣�Cube2 ��
            rend1.material.color = Color.green;
            rend2.material.color = Color.red;
            yield return new WaitForSeconds(10f);

            // Cube1 �죬Cube2 ��
            rend1.material.color = Color.red;
            rend2.material.color = Color.green;
            yield return new WaitForSeconds(10f);
        }
    }
}
