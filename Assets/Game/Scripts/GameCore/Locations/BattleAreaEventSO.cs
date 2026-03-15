using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleAreaEvent_", menuName = "ScriptableObjects/Locations/Events/Battle Area Event")]
public class BattleAreaEventSO : BaseAreaEventSO
{
    [SerializeField] private List<CharacterSO> m_enemies;

    public List<CharacterSO> Enemies => m_enemies;
}
