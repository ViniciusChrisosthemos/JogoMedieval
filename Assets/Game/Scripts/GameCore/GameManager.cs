using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private SocialLinkManager m_socialLinkManager;
    [SerializeField] private CameraManager m_cameraManager;
    [SerializeField] private MapManager m_mapManager;
    [SerializeField] private DayManager m_dayManager;
    [SerializeField] private MainHUDView m_mainHUDView;

    [Header("Events")]
    public UnityEvent<GameContext> OnGameContextReady;

    [Header("Debug")]
    [SerializeField] private List<BaseContractSO> m_initialContracts;
    [SerializeField] private LevelDataSO m_popularityLevelSO;


    private void Start()
    {
        GameContext = new GameContext();

        LoadManagers();

        m_mapManager.Setup(GameContext);
        m_mainHUDView.Setup(this);

        m_mapManager.EnterLocation();
    }

    private void LoadManagers()
    {
        GameContext.AddReference(m_socialLinkManager);
        GameContext.AddReference(m_cameraManager);
        GameContext.AddReference(m_mapManager);
        GameContext.AddReference(m_dayManager);

        GameContext.AddReference(new PlayerManager());

        var popularityLevelData = LevelFactory.CreateLevelData(m_popularityLevelSO);
        var guildData = new GuildData(popularityLevelData);
        GameContext.AddReference(new GuildManager(guildData));

        var contracts = ContractFactory.CreateContractData(m_initialContracts);
        GameContext.AddReference(new ContractManager(contracts, new List<BaseContractData>()));

        OnGameContextReady?.Invoke(GameContext);
    }

    public GameContext GameContext { get; private set; }
}
