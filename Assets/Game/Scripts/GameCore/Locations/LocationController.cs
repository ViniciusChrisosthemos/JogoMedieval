using UnityEngine;

public class LocationController : MonoBehaviour
{
    [SerializeField] private AreaLocationDataSO m_areaLocationDataSO;

    private AreaLocationData m_areaLocationData;

    private void Awake()
    {
        m_areaLocationData = new AreaLocationData(m_areaLocationDataSO);
    }


}
