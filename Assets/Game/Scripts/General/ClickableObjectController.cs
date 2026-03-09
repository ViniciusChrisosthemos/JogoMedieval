using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableObjectController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Events")]
    [SerializeField] private UnityEvent OnClickEvent; 
    [SerializeField] private UnityEvent OnPointerEnterEvent; 
    [SerializeField] private UnityEvent OnPointerExitEvent;
    [SerializeField] private UnityEvent OnEnabled;

    private void OnEnable()
    {
        OnEnabled?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke();
    }
}
