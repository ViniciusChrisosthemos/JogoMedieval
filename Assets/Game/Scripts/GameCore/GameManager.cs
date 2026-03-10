using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private SocialLinkManager m_socialLinkManager;
    [SerializeField] private CameraManager m_cameraManager;
    [SerializeField] private MapManager m_mapManager;
    [SerializeField] private MainHUDView m_mainHUDView;

    [Header("Debug")]
    [SerializeField] private List<BaseContractSO> m_initialContracts;
    [SerializeField] private LevelDataSO m_popularityLevelSO;


    private GameContext m_gameContext;

    private void Start()
    {
        m_gameContext = new GameContext();

        LoadManagers();

        m_mapManager.EnterLocation();
        m_mainHUDView.Setup(this);
    }

    private void LoadManagers()
    {
        m_gameContext.AddReference(m_socialLinkManager);
        m_gameContext.AddReference(m_cameraManager);
        m_gameContext.AddReference(m_mapManager);

        m_gameContext.AddReference(new PlayerManager());

        var popularityLevelData = LevelFactory.CreateLevelData(m_popularityLevelSO);
        var guildData = new GuildData(popularityLevelData);
        m_gameContext.AddReference(new GuildManager(guildData));

        var contracts = ContractFactory.CreateContractData(m_initialContracts);
        m_gameContext.AddReference(new ContractManager(contracts, new List<BaseContractData>()));

        m_mapManager.Setup(m_gameContext);
    }

    public GameContext GameContext => m_gameContext;
}
