using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData_", menuName = "ScriptableObjects/General/Level Data")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private List<int> m_expPerLevel;
    
    public List<int> ExpPerLevel => m_expPerLevel;
}
