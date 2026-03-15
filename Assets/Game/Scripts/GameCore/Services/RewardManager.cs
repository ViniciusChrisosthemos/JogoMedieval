using UnityEngine;

public static class RewardManager
{
    public static RewardData GetReward(RewardParameters rewardParameters, BattleResult battleResult)
    {
        // TODO: Aplicar alguma regra caso o jogador perca o combate
        return ComputeReward(rewardParameters);
    }

    public static RewardData GetReward(RewardParameters rewardParameters)
    {
        return ComputeReward(rewardParameters);
    }

    private static RewardData ComputeReward(RewardParameters rewardParameters)
    {
        var gold = rewardParameters.Gold;
        var exp = rewardParameters.Exp;
        var popularity = rewardParameters.Popularity;
        var items = rewardParameters.GetItems();

        return new RewardData(gold, exp, popularity, items);
    }
}
