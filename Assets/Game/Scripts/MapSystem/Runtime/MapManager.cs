using System;
using UnityEngine;
using UnityEngine.Events;

public class MapManager : MonoBehaviour, ILocationManager
{
    [SerializeField] private AbstractLocationController m_startLocation;
    [SerializeField] private Transform m_locationParent;

    [Header("Events")]
    public UnityEvent<AbstractLocationController> OnChangeLocation;

    private AbstractLocationController m_currentLocation;

    public void Setup(IGameContext gameContext)
    {
        var controllers = m_locationParent.GetComponentsInChildren<AbstractLocationController>();

        foreach (var controller in controllers) controller.Setup(this, gameContext);

        m_currentLocation = m_startLocation;
    }

    public void EnterLocation()
    {
        m_currentLocation.Enter();
    }

    public void MoveTo(AbstractLocationController locationController)
    {
        m_currentLocation.Exit();

        m_currentLocation = locationController;

        EnterLocation();

        OnChangeLocation?.Invoke(m_currentLocation);
    }

    public void GoBack()
    {
        if (m_currentLocation != null && m_currentLocation.LocationParent != null)
        {
            MoveTo(m_currentLocation.LocationParent);
        }
    }
}
