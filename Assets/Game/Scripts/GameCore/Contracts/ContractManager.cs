using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ContractManager
{
    public event Action<BaseContractData> OnContractAdded;
    public event Action<BaseContractData> OnContractCompleted;

    public List<BaseContractData> AvailableContracts { get; private set; }
    public List<BaseContractData> OngoingContracts { get; private set; }

    public ContractManager() : this(new List<BaseContractData>(), new List<BaseContractData>()) { }

    public ContractManager(List<BaseContractData> availableContracts, List<BaseContractData> ongoingContracts)
    {
        AvailableContracts = availableContracts;
        OngoingContracts = ongoingContracts;
    }

    public void AddContracts(BaseContractData contract)
    {
        AvailableContracts.Add(contract);
    }

    public void AccepContract(BaseContractData contract)
    {
        AvailableContracts.Remove(contract);
        OngoingContracts.Add(contract);

        OnContractAdded?.Invoke(contract);
    }

    public void CompleteContract(IGameContext gameContext, BaseContractData contract)
    {
        var guildManager = gameContext.GetReference<GuildManager>();

        var rewardData = RewardManager.GetReward(contract.RewardParameters);

        guildManager.AddPopularity(rewardData.Popularity);

        var playerManager = gameContext.GetReference<PlayerManager>();
        playerManager.CommitReward(rewardData);

        OnContractCompleted?.Invoke(contract);
    }

    public void RefuseContract(BaseContractData contract)
    {
        AvailableContracts.Remove(contract);
    }
}
