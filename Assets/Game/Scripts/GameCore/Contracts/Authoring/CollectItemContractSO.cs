using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectContract_", menuName = "ScriptableObjects/Contracts/Collect Items")]
public class CollectItemContractSO : BaseContractSO
{
    [SerializeField] private List<ObjectAmountData<BaseItem>> m_requiredItems;

    public List<ObjectAmountData<BaseItem>> RequiredItems => m_requiredItems;
}
