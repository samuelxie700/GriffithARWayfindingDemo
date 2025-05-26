using UnityEngine;

public class PlayerEmergencyTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SafeBuilding"))
        {
            EmergencyManager manager = FindObjectOfType<EmergencyManager>();
            if (manager != null && manager.IsEmergencyActive())
            {
                manager.StopEmergencyExternally();
            }
        }
    }
}
