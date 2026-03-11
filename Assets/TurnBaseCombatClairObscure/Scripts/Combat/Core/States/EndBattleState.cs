using UnityEngine;

public class EndBattleState : BaseBattleState
{

    public EndBattleState(CombatManager combatManager) : base(combatManager)
    {
    }

    public override void Enter()
    {
        CombatManager.UIEndBattleView.Setup(CombatManager.GetBattleResult(), HandleEndBattle);
    }

    public override void Exit()
    {
        CombatManager.UIEndBattleView.Close();
    }

    public override void UpdateState()
    {

    }

    private void HandleEndBattle()
    {
        CombatManager.EndCombat();
    }
}
