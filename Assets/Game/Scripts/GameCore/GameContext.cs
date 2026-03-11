using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : IGameContext
{
    private Dictionary<Type, object> m_references;

    public GameContext()
    {
        m_references = new Dictionary<Type, object>();
    }

    public void AddReference<T>(T reference)
    {
        m_references.Add(typeof(T), reference);
    }

    public T GetReference<T>()
    {
        var type = typeof(T);
        if (m_references.ContainsKey(type)) return (T)m_references[type];

        throw new Exception($"Service {typeof(T)} not registered");
    }
}
