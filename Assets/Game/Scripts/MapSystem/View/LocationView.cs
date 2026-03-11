using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationView : MonoBehaviour
{
    [SerializeField] private GameObject m_lockerVisual;
    [SerializeField] private ClickableObjectController m_clickableObjectController;

    public void SetLocationLocked(bool isLocked)
    {
        m_lockerVisual.SetActive(isLocked);
        m_clickableObjectController.enabled = !isLocked;
    }
}
