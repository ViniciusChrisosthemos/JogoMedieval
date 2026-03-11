using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public PlayerManager(CharacterSO playerCharacter)
    {
        PlayerTeam = new List<CharacterSO>() { playerCharacter };
    }

    public void AddExperience(int exp)
    {

    }

    public void AddGold(int gold)
    {

    }

    public void RemoveGold(int gold)
    {

    }

    public int Gold { get; private set; }
    public List<CharacterSO> PlayerTeam { get; private set; }
}
