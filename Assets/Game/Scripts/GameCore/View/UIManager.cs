using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ExplorationSpotHUDView m_explorationView;

    public void OpenExplorationView(ExplorationAreaHandlerLocationCallback handler)
    {
        m_explorationView.OpenScreen();
        m_explorationView.Setup(handler);
    }

    public void CloseExplorationView()
    {
        m_explorationView.CloseScreen();
    }
}
