using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaLocation_", menuName = "ScriptableObjects/Locations/Area Location")]
public class AreaLocationDataSO : ScriptableObject
{
    [SerializeField] private string m_id;
    [SerializeField] private string m_description;
    [SerializeField] private List<AreaLocationDataSO> m_nextAreas;
    [SerializeField] private List<BaseAreaEventSO> m_events;

    public string ID => m_id;
    public string Description => m_description;
    public List<AreaLocationDataSO> NextAreas => m_nextAreas;
    public List<BaseAreaEventSO> Events => m_events;
}
