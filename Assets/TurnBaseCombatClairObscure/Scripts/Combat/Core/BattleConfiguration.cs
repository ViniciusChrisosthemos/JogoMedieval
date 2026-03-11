using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BattleConfiguration
{
    public BattleConfiguration(List<CharacterSO> playerTeam, List<CharacterSO> enemies)
    {
        PlayerTeam = playerTeam;
        EnemyTeam = enemies;
    }

    public List<CharacterSO> PlayerTeam {  get; private set; }   
    public List<CharacterSO> EnemyTeam { get; private set; }
}
