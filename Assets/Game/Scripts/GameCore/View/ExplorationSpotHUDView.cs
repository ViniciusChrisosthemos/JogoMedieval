using UnityEngine;
using UnityEngine.UI;

public class ExplorationSpotHUDView : BaseUIInterface
{
    [SerializeField] private Button m_btnStartBattle;

    private void Awake()
    {
        m_btnStartBattle.onClick.AddListener(HandleStartBattle);

        CloseScreen();
    }

    private void HandleStartBattle()
    {
        GameManager.Instance.StartBattle();
    }
}
