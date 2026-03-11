using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RegioanView : MonoBehaviour
{
    [SerializeField] private Transform m_explorationAreaParent;

    private List<ExplorationAreaHandlerLocationCallback> m_explorationHandlers;

    private void Start()
    {
        m_explorationHandlers = m_explorationAreaParent.GetComponentsInChildren<ExplorationAreaHandlerLocationCallback>().ToList();
        m_explorationHandlers.ForEach(handler => handler.Setup(this));
    }

    public void UpdateHandlers()
    {
        m_explorationHandlers.ForEach(handler => handler.UpdateVisual());
    }
}
