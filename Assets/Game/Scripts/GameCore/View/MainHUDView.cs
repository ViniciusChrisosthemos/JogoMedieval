using System;
using UnityEngine;
using UnityEngine.UI;

public class MainHUDView : MonoBehaviour
{
    [SerializeField] private Button m_btnGoBack;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_btnGoBack.onClick.AddListener(HandleGoBackEvent);
        m_btnGoBack.interactable = false;
    }

    private void HandleGoBackEvent()
    {
        var mapManager = m_gameManager.GameContext.GetReference<MapManager>();
        mapManager.GoBack();
    }

    private void HandleLocationChanged(AbstractLocationController newLocation)
    {
        m_btnGoBack.interactable = newLocation.LocationParent != null;
    }

    public void Setup(GameManager gameManager)
    {
        m_gameManager = gameManager;

        var mapManager = gameManager.GameContext.GetReference<MapManager>();
        mapManager.OnChangeLocation.AddListener(HandleLocationChanged);
    }
}
