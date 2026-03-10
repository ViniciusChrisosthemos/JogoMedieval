using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public event Action OnLevelUp;
    public event Action OnLevelDown;

    public LevelData(int level, int currentExp, List<int> expPerLevels)
    {
        Level = level;
        CurrentExp = currentExp;
        ExpPerLevels = expPerLevels;
    }

    public void AddExp(int exp)
    {
        var hasLevelUp = false;

        CurrentExp += exp;

        while (CurrentExp >= ExpToNextLevel && !IsMaxLevel)
        {
            CurrentExp -= ExpToNextLevel;

            Level++;

            hasLevelUp = true;
        }

        if (hasLevelUp) OnLevelUp?.Invoke();
    }

    public void RmvExp(int exp)
    {
        var hasLevelDown = false;

        CurrentExp -= exp;

        while (CurrentExp < 0 && Level > 0)
        {
            Level--;
            CurrentExp = ExpToNextLevel - Math.Abs(CurrentExp);


            hasLevelDown = true;
        }

        if (hasLevelDown) OnLevelDown?.Invoke();
    }

    public bool IsMaxLevel => Level == ExpPerLevels.Count;
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    private List<int> ExpPerLevels {  get; set; }
    public int ExpToNextLevel => Level < ExpPerLevels.Count ? ExpPerLevels[Level] : 0;
}
