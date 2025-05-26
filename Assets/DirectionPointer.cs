using UnityEngine;
using TMPro;

public class DirectionPointer : MonoBehaviour
{
    public Transform player;                  // 玩家
    public RectTransform arrowUI;             // UI箭头
    public TMP_InputField searchField;        // 搜索框

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
            Debug.LogWarning("未找到目标：" + input);
            target = null;
        }
    }

    void Update()
    {
        if (player == null || target == null || arrowUI == null) return;

        // 从玩家指向目标的方向
        Vector3 dir = target.position - player.position;

        // 计算角度（X-Z 平面）
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        // 只旋转 UI（不改位置）
        arrowUI.rotation = Quaternion.Euler(0, 0, -angle);
    }
}

