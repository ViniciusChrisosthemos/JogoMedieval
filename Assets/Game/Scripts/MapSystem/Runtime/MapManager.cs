using UnityEngine;

public class MapManager : MonoBehaviour, ILocationManager
{
    [SerializeField] private AbstractLocationController m_startLocation;
    [SerializeField] private Transform m_locationParent;

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
        if (!(locationController is SubLocationController) || ((m_currentLocation is SubLocationController) && (locationController is SubLocationController)))
        {
            m_currentLocation.Exit();
        }

        m_currentLocation = locationController;

        EnterLocation();
    }
}
