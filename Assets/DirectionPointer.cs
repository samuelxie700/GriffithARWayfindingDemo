using UnityEngine;
using TMPro;

public class DirectionPointer : MonoBehaviour
{
    public Transform player;                  // ���
    public RectTransform arrowUI;             // UI��ͷ
    public TMP_InputField searchField;        // ������

    private Transform target;

    void Start()
    {
        searchField.onEndEdit.AddListener(OnSearch);
    }

    void OnSearch(string input)
    {
        GameObject found = GameObject.Find(input);
        if (found != null)
        {
            target = found.transform;
        }
        else
        {
            Debug.LogWarning("δ�ҵ�Ŀ�꣺" + input);
            target = null;
        }
    }

    void Update()
    {
        if (player == null || target == null || arrowUI == null) return;

        // �����ָ��Ŀ��ķ���
        Vector3 dir = target.position - player.position;

        // ����Ƕȣ�X-Z ƽ�棩
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        // ֻ��ת UI������λ�ã�
        arrowUI.rotation = Quaternion.Euler(0, 0, -angle);
    }
}

