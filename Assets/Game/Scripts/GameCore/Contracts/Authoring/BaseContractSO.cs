using UnityEngine;

public class BaseContractSO : ScriptableObject
{
    [SerializeField] private string m_title;
    [SerializeField] private string m_baseDescription;
    [SerializeField] private RewardParameters m_rewardData;

    public string Title => m_title;
    public string BaseDescription => m_baseDescription;
    public RewardParameters RewardData => m_rewardData;
}
