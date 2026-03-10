using UnityEngine;

public class BaseContractSO : ScriptableObject
{
    [SerializeField] private string m_title;
    [SerializeField] private string m_baseDescription;
    [SerializeField] private RewardData m_rewardData;

    public string Title => m_title;
    public string BaseDescription => m_baseDescription;
    public RewardData RewardData => m_rewardData;
}
