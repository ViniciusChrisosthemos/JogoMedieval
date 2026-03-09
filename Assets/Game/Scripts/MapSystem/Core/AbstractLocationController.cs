using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLocationController : MonoBehaviour
{
    [SerializeField] protected GameObject m_view;
    [SerializeField] private List<AbstractLocationCallback> m_enterCallbacks;
    [SerializeField] private List<AbstractLocationCallback> m_exitCallbacks;

    protected IGameContext m_gameContext;
    protected ILocationManager m_locationManager;

    public void Setup(ILocationManager locationManager, IGameContext gameContext)
    {
        m_gameContext = gameContext;
        m_locationManager = locationManager;

        m_view.SetActive(false);
    }

    public void Enter()
    {
        m_enterCallbacks.ForEach(callback => callback.HandleEnterLocation(m_gameContext));
        HandleEnterInternal();
        m_view.SetActive(true);
    }

    public void Exit()
    {
        m_exitCallbacks.ForEach(callback => callback.HandleExitLocation(m_gameContext));
        HandleExitInternal();
        m_view.SetActive(false);
    }

    public abstract void HandleEnterInternal();
    public abstract void HandleExitInternal();
}
