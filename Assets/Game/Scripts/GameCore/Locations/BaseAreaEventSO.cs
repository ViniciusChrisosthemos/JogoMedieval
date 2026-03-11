using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseAreaEventSO : ScriptableObject
{
    [SerializeField] private List<string> m_narratives;

    public List<string> Narratives => m_narratives;
}
