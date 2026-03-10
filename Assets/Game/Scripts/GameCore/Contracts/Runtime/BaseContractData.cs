using UnityEngine;

public abstract class BaseContractData
{
    public string Title { get; private set; }
    protected string BaseDescription { get; private set; }
    public RewardData RewardData { get; private set; }

    public BaseContractData(string title, string baseDescription, RewardData rewardData)
    {
        Title = title;
        BaseDescription = baseDescription;
        RewardData = rewardData;
    }

    public abstract bool CheckConditions(IGameContext gameContext);

    public virtual string GetDescription() => BaseDescription;
}
