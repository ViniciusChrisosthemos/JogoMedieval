using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SocialLinkManager m_socialLinkManager;
    [SerializeField] private CameraManager m_cameraManager;
    [SerializeField] private MapManager m_mapManager;

    public AbstractLocationController m_location_1;
    public AbstractLocationController m_location_2;
    public AbstractLocationController m_location_3;

    private GameContext m_gameContext;

    private void Start()
    {
        m_gameContext = new GameContext();

        m_gameContext.AddReference(m_socialLinkManager);
        m_gameContext.AddReference(m_cameraManager);

        m_mapManager.Setup(m_gameContext);

        m_mapManager.EnterLocation();
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            m_mapManager.MoveTo(m_location_1);

            Debug.Log("Q");
        }
        else if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            m_mapManager.MoveTo(m_location_2);
            Debug.Log("W");
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            m_mapManager.MoveTo(m_location_3);
            Debug.Log("E");
        }
    }
}
