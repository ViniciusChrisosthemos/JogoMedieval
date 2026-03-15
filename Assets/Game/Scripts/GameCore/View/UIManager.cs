using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MainHUDView m_mainHUDView;
    [SerializeField] private ExplorationSpotHUDView m_explorationView;
    [SerializeField] private UIQuestManagerView m_questManagerView;

    public void OpenExplorationView(ExplorationAreaHandlerLocationCallback handler)
    {
        m_explorationView.OpenScreen();
        m_explorationView.Setup(handler);
    }

    public void CloseExplorationView()
    {
        m_explorationView.CloseScreen();
    }

    public void Setup(GameManager gameManager)
    {
        m_mainHUDView.Setup(gameManager);
        m_questManagerView.Setup(gameManager);
    }

    public ExplorationSpotHUDView ExplorationView => m_explorationView;
}
