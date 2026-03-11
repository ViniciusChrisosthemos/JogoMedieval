using DG.Tweening;
using UnityEngine;

public class SunView : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameManager m_gameManager;


    [Header("References")]
    [SerializeField] private Transform m_sunTransform;

    [Header("Spots")]
    [SerializeField] private Transform m_defaultTransform;
    [SerializeField] private Transform m_morningTransform;
    [SerializeField] private Transform m_dayTransform;
    [SerializeField] private Transform m_afternoonTransform;
    [SerializeField] private Transform m_nightTransform;

    [Header("Parameters")]
    [SerializeField] private float m_moveDuration = 1f;
    [SerializeField] private float m_arcHeight = 3f;

    private void Awake()
    {
        m_gameManager.OnGameContextReady.AddListener(Setup);
    }

    public void Setup(GameContext gameContext)
    {
        var dayManager = gameContext.GetReference<DayManager>();

        dayManager.OnDayTimeChanged += HandleDayTimeChanged;
    }

    private void HandleDayTimeChanged(DayTime dayTime)
    {
        var endTransform = m_sunTransform;

        switch (dayTime)
        {
            case DayTime.Morning:
                m_sunTransform.position = m_defaultTransform.position;
                m_sunTransform.rotation = m_defaultTransform.rotation;

                endTransform = m_morningTransform; break;
            case DayTime.Day: endTransform = m_dayTransform; break;
            case DayTime.Afternoon: endTransform = m_afternoonTransform; break;
            case DayTime.Night: endTransform = m_nightTransform; break;
            default: break;
        }

        MoveToPosition(m_sunTransform, endTransform, m_moveDuration, m_arcHeight);
    }

    private void MoveToPosition(Transform objectTrasform, Transform targetTranform, float duration, float arcHeight)
    {
        var startPosition = objectTrasform.position;
        var endPosition = targetTranform.position;
        var midPoint = (startPosition + endPosition) / 2;

        midPoint.y += arcHeight;

        var path = new Vector3[] { startPosition, midPoint, endPosition };

        objectTrasform.DOPath(path, duration, PathType.CatmullRom).SetEase(Ease.OutQuad);
        objectTrasform.DORotate(targetTranform.eulerAngles, duration);
    }
}
