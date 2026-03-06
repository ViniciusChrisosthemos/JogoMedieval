using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLocationController : MonoBehaviour
{
    [SerializeField] private GameObject m_view;
    [SerializeField] private List<AbstractLocationCallback> m_callbacks;

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
        m_view.SetActive(true);

        HandleEnterInternal();

        m_callbacks.ForEach(callback => callback.HandleEnterLocation(m_gameContext));
    }

    public void Exit()
    {
        m_view.SetActive(false);

        HandleExitInternal();
    }

    public abstract void HandleEnterInternal();
    public abstract void HandleExitInternal();
}
