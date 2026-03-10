using UnityEngine;

public static class LevelFactory
{
    public static LevelData CreateLevelData(LevelDataSO levelDataSO)
    {
        return new LevelData(0, 0, levelDataSO.ExpPerLevel);
    }
}
