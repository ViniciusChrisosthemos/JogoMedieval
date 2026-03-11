using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DayManager : MonoBehaviour
{
    public event Action<DayTime> OnDayTimeChanged;

    private void Awake()
    {
        DayTime = DayTime.Morning;
    }

    private void Update()
    {
        //if (Keyboard.current.pKey.wasPressedThisFrame) PassTime();
    }

    public void SetDayTime(DayTime dayTime)
    {
        DayTime = dayTime;

        OnDayTimeChanged?.Invoke(DayTime);
    }

    public void PassTime()
    {
        switch (DayTime)
        {
            case DayTime.Morning: DayTime = DayTime.Day; break;
            case DayTime.Day: DayTime = DayTime.Afternoon; break;
            case DayTime.Afternoon: DayTime = DayTime.Night; break;
            case DayTime.Night: DayTime = DayTime.Morning; break;
            default: DayTime = DayTime.Morning; break;        
        }

        OnDayTimeChanged?.Invoke(DayTime);
    }

    public DayTime DayTime { get; private set; }
}
