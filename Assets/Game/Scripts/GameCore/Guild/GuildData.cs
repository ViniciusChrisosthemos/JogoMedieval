using UnityEngine;

public class GuildData
{
    private LevelData m_popularity;

    public GuildData(LevelData popularityLevelData)
    {
        m_popularity = popularityLevelData;
    }

    public void AddPopularity(int popularity)
    {
        m_popularity.AddExp(popularity);
    }

    public void RmvPopularity(int popularity)
    {
        m_popularity.RmvExp(popularity);
    }
}
