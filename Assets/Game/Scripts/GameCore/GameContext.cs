using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : IGameContext
{
    private List<object> m_references;

    public GameContext()
    {
        m_references = new List<object>();
    }

    public void AddReference<T>(T reference)
    {
        m_references.Add((object)reference);
    }

    public T GetReference<T>()
    {
        var reference = m_references.Find(obj => obj is T);

        return (T)reference;
    }
}
