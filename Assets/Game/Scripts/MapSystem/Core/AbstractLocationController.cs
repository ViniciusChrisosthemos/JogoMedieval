using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractLocationController : MonoBehaviour
{
    [SerializeField] private AbstractLocationController m_locationParent;
    [SerializeField] private GameObject m_subSpotsParent;

    [Header("Events")]
    public UnityEvent<IGameContext> OnEnterEvent;
    public UnityEvent<IGameContext> OnExitEvent;

    protected IGameContext m_gameContext;
    protected ILocationManager m_locationManager;

    public void Setup(ILocationManager locationManager, IGameContext gameContext)
    {
        m_gameContext = gameContext;
        m_locationManager = locationManager;

        m_subSpotsParent.SetActive(false);
    }

    public void Enter()
    {
        HandleEnterInternal();

        OnEnterEvent?.Invoke(GameManager.Instance.GameContext);

        m_subSpotsParent.SetActive(true);
    }

    public void Exit()
    {
        HandleExitInternal();

        OnExitEvent?.Invoke(GameManager.Instance.GameContext);

        m_subSpotsParent.SetActive(false);
    }

    public AbstractLocationController LocationParent => m_locationParent;

    public abstract void HandleEnterInternal();
    public abstract void HandleExitInternal();
}
