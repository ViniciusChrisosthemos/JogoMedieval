using System;
using UnityEngine;

public class BattleManager
{
    public event Action<BattleResult> OnBattleEnded;

    public BattleManager() { }

    public void StarBattle(BattleConfiguration battleConfiguration)
    {
        BattleConfiguration = battleConfiguration;

        GameManager.Instance.StartBattle();
    }

    public async void EndBattle(BattleResult battleResult)
    {
        BattleResult = battleResult;

        await GameManager.Instance.EndBattle();
        
        OnBattleEnded?.Invoke(battleResult);
    }


    public BattleResult BattleResult { get; private set; }
    public BattleConfiguration BattleConfiguration { get; private set; }
}
