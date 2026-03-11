using UnityEngine;

public abstract class BaseUIInterface : MonoBehaviour
{
    [SerializeField] private GameObject m_view;

    public void OpenScreen()
    {
        m_view.SetActive(true);

        HandleScreenOpened();
    }

    public void CloseScreen()
    {
        m_view?.SetActive(false);

        HandleScreenClosed();
    }

    protected virtual void HandleScreenOpened()
    {

    }

    protected virtual void HandleScreenClosed()
    {

    }
}
