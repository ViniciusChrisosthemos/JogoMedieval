using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public static class ContractFactory
{
    public static CollectItemContractData CreateCollectItemContractData(CollectItemContractSO contractSO)
    {
        return new CollectItemContractData(contractSO.Title,
                                           contractSO.BaseDescription,
                                           contractSO.RewardData,
                                           contractSO.RequiredItems);
    }

    public static List<BaseContractData> CreateContractData(List<BaseContractSO> contractsSO)
    {
        var contractData = new List<BaseContractData>();

        foreach (var contract in contractsSO)
        {
            switch (contract)
            {
                case CollectItemContractSO contractSO: contractData.Add(CreateCollectItemContractData(contractSO)); break;
                default: continue;
            }
        }

        return contractData;
    }
}
