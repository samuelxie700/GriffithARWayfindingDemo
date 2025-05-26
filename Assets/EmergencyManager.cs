using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EmergencyManager : MonoBehaviour
{
    public Button emergencyButton;
    public Camera mainCamera;

    private bool emergencyActive = false;
    private Coroutine shakeRoutine;
    private Coroutine flashRoutine;
    private Vector3 originalCameraPos;

    private GameObject[] dangerBuildings;
    private GameObject[] safeBuildings;

    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>();

    void Start()
    {
        emergencyButton.onClick.AddListener(ToggleEmergency);
    }

    void ToggleEmergency()
    {
        emergencyActive = !emergencyActive;

        if (emergencyActive)
        {
            // 查找建筑
            dangerBuildings = GameObject.FindGameObjectsWithTag("DangerBuilding");
            safeBuildings = GameObject.FindGameObjectsWithTag("SafeBuilding");

            // 保存初始颜色
            originalColors.Clear();
            foreach (var obj in dangerBuildings) CacheOriginalColor(obj);
            foreach (var obj in safeBuildings) CacheOriginalColor(obj);

            // 摄像机震动 + 建筑闪烁
            originalCameraPos = mainCamera.transform.localPosition;
            shakeRoutine = StartCoroutine(ShakeCamera());
            flashRoutine = StartCoroutine(FlashBuildings());
        }
        else
        {
            StopEmergency();
        }
    }

    void StopEmergency()
    {
        // 停止协程
        if (shakeRoutine != null) StopCoroutine(shakeRoutine);
        if (flashRoutine != null) StopCoroutine(flashRoutine);

        // 恢复颜色和位置
        ResetAllColors();
        mainCamera.transform.localPosition = originalCameraPos;
        emergencyActive = false;
    }

    IEnumerator ShakeCamera()
    {
        while (true)
        {
            Vector3 offset = Random.insideUnitSphere * 0.3f;
            offset.z = 0;
            mainCamera.transform.localPosition = originalCameraPos + offset;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FlashBuildings()
    {
        while (emergencyActive)
        {
            foreach (var obj in dangerBuildings) SetColor(obj, Color.red);
            foreach (var obj in safeBuildings) SetColor(obj, Color.green);
            yield return new WaitForSeconds(2f);

            foreach (var obj in dangerBuildings) SetColor(obj, Color.gray);
            foreach (var obj in safeBuildings) SetColor(obj, Color.gray);
            yield return new WaitForSeconds(2f);
        }
    }

    void SetColor(GameObject obj, Color color)
    {
        Renderer r = obj.GetComponent<Renderer>();
        if (r != null)
            r.material.color = color;
    }

    void CacheOriginalColor(GameObject obj)
    {
        Renderer r = obj.GetComponent<Renderer>();
        if (r != null && !originalColors.ContainsKey(obj))
        {
            originalColors[obj] = r.material.color;
        }
    }

    void ResetAllColors()
    {
        if (dangerBuildings != null)
        {
            foreach (var obj in dangerBuildings)
            {
                if (originalColors.ContainsKey(obj))
                    SetColor(obj, originalColors[obj]);
            }
        }

        if (safeBuildings != null)
        {
            foreach (var obj in safeBuildings)
            {
                if (originalColors.ContainsKey(obj))
                    SetColor(obj, originalColors[obj]);
            }
        }
    }

    // 提供给玩家触发停止用
    public void StopEmergencyExternally()
    {
        if (emergencyActive)
            StopEmergency();
    }

    public bool IsEmergencyActive()
    {
        return emergencyActive;
    }
}

