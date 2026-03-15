using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RewardParameters
{
    [SerializeField] private int m_gold;
    [SerializeField] private int m_exp;
    [SerializeField] private int m_popularity;
    [SerializeField] private List<ItemDropData> m_drops;

    private List<ItemHolder> m_rewardedItems;

    public int Gold => m_gold;
    public int Exp => m_exp;
    public int Popularity => m_popularity;

    public List<ItemHolder> GetItems()
    {
        m_rewardedItems = new List<ItemHolder>();

        foreach (var item in m_drops)
        {
            var value = UnityEngine.Random.Range(0f, 1f);

            if (value <= item.Probability)
            {
                var randomTime = UnityEngine.Random.Range(0f, 1f);
                var amount = Mathf.RoundToInt(item.AmountCurveProbability.Evaluate(randomTime) * (item.MaxAmount - item.MinAmount) + item.MinAmount);

                m_rewardedItems.Add(new ItemHolder(item.Item, amount));
            }
        }

        return m_rewardedItems;
    }

    [Serializable]
    internal class ItemDropData
    {
        public int MinAmount;
        public int MaxAmount;
        public AnimationCurve AmountCurveProbability;
        public float Probability;
        public BaseItem Item;
    }
}
