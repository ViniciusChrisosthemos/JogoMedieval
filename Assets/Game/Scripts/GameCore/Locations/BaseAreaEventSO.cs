using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseAreaEventSO : ScriptableObject
{
    [SerializeField] private List<string> m_narratives;
    [SerializeField] private RewardParameters m_rewardParameters;

    public List<string> Narratives => m_narratives;

    public RewardParameters GetRewardParamters()
    {
        return m_rewardParameters;
    }
}
