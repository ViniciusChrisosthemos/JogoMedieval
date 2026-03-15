using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplorationAreaHandlerLocationCallback : AbstractLocationCallback
{
    [SerializeField] private AreaLocationDataSO m_areaLocationDataSO;
    [SerializeField] private List<ExplorationAreaHandlerLocationCallback> m_dependecies;

    [Header("Visuals")]
    [SerializeField] private LocationView m_locationView;

    private RegioanView m_regionView;

    private void Awake()
    {
        AreaLocationData = new AreaLocationData(m_areaLocationDataSO);
    }

    public override void HandleEnterLocation(IGameContext gameContext)
    {
        var uiManager = gameContext.GetReference<UIManager>();

        uiManager.OpenExplorationView(this);
    }

    public override void HandleExitLocation(IGameContext gameContext)
    {
        var uiManager = gameContext.GetReference<UIManager>();

        uiManager.CloseExplorationView();
    }

    public void HandleBattleAreaEvent(BattleAreaEventSO battleAreaEventSO)
    {
        var playerManager = GameManager.Instance.GameContext.GetReference<PlayerManager>();
        var battleManager = GameManager.Instance.GameContext.GetReference<BattleManager>();

        var playerTeam = playerManager.PlayerTeam;
        var enemyTeam = battleAreaEventSO.Enemies;
        var battleConfiguration = new BattleConfiguration(playerTeam, enemyTeam);

        battleManager.OnBattleEnded += HandleBattleResult;
        battleManager.StarBattle(battleConfiguration);
    }

    private void HandleBattleResult(BattleResult battleResult)
    {
        var gameContext = GameManager.Instance.GameContext;
        var battleManager = gameContext.GetReference<BattleManager>();

        battleManager.OnBattleEnded -= HandleBattleResult;

        if (battleResult.PlayerWin)
        {
            var rewardParameters = AreaLocationData.GetRewardParameters();
            AreaLocationData.CompleteEvent();

            m_regionView.UpdateHandlers();

            var rewardData = RewardManager.GetReward(rewardParameters, battleResult);

            var playerManager = gameContext.GetReference<PlayerManager>();
            playerManager.CommitReward(rewardData);

            var uiManager = gameContext.GetReference<UIManager>();
            uiManager.ExplorationView.ShowRewardData(rewardData, () => HandleEnterLocation(gameContext));
        }
    }

    public void SetAreaLocked(bool isLocked)
    {
        m_locationView.SetLocationLocked(isLocked);
    }

    public void UpdateVisual()
    {
        var isAvailable = m_dependecies.All(handler => handler.AreaLocationData.IsCompleted) || m_dependecies.Count == 0;

        SetAreaLocked(!isAvailable);
    }

    public void Setup(RegioanView regioanView)
    {
        m_regionView = regioanView;
    }

    public AreaLocationData AreaLocationData { get; internal set; }
}
