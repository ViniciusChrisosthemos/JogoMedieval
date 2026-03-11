using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AreaLocationData
{
    public AreaLocationData(AreaLocationDataSO dataSO)
    {
        ID = dataSO.ID;
        Description = dataSO.Description;
        Events = dataSO.Events;
        CurrentExplorationAmount = 0;
        NextAreas = dataSO.NextAreas;
    }

    public string ID { get; private set; }
    public string Description { get; private set; }
    public int CurrentExplorationAmount { get; private set; }
    private List<BaseAreaEventSO> Events { get; set; }
    public int ExplorationRequired => Events.Count;
    public BaseAreaEventSO CurrentEvent => Events[CurrentExplorationAmount];
    public List<AreaLocationDataSO> NextAreas { get; private set; } 
    public bool IsCompleted => CurrentExplorationAmount == ExplorationRequired;

    public void CompleteEvent()
    {
        CurrentExplorationAmount++;
    }
}
