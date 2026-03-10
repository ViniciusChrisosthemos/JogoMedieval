using UnityEngine;

public class GuildManager
{
    private GuildData m_guildData;

    public GuildManager(GuildData guildData)
    {
        m_guildData = guildData;
    }

    public void AddPopularity(int popularity)
    {
        m_guildData.AddPopularity(popularity);
    }

    public void RemovePopularity(int popularity)
    {
        m_guildData.RmvPopularity(popularity);
    }
}
