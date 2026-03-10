using System;
using UnityEngine;

[Serializable]
public class RewardData
{
    [SerializeField] private int m_gold;
    [SerializeField] private int m_exp;
    [SerializeField] private int m_popularity;

    public int Gold => m_gold;
    public int Exp => m_exp;
    public int Popularity => m_popularity;
}
