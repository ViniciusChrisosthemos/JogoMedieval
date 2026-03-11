using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ExplorationSpotHUDView m_explorationView;

    public void OpenExplorationView()
    {
        m_explorationView.OpenScreen();
    }

    public void CloseExplorationView()
    {
        m_explorationView.CloseScreen();
    }
}
