using NUnit.Framework;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationSpotHUDView : BaseUIInterface
{
    [SerializeField] private TextMeshProUGUI m_description;
    [SerializeField] private TextMeshProUGUI m_levels;
    [SerializeField] private Button m_btnExplore;

    private ExplorationAreaHandlerLocationCallback m_handler;

    private void Awake()
    {
        m_btnExplore.onClick.AddListener(HandleExploreAction);

        CloseScreen();
    }

    private void HandleExploreAction()
    {
        var areaEvent = m_handler.AreaLocationData.CurrentEvent;

        switch (areaEvent)
        {
            case BattleAreaEventSO battleAreaEventSO: m_handler.HandleBattleAreaEvent(battleAreaEventSO); break;
            default: break;
        }
    }

    public void Setup(ExplorationAreaHandlerLocationCallback explorationAreaHandler)
    {
        m_handler = explorationAreaHandler;

        m_description.text = m_handler.AreaLocationData.Description;
        m_levels.text = $"{m_handler.AreaLocationData.CurrentExplorationAmount}/{m_handler.AreaLocationData.ExplorationRequired}";

        m_btnExplore.interactable = !m_handler.AreaLocationData.IsCompleted;
    }
}
