using UnityEngine;

public abstract class AbstractLocationCallback : MonoBehaviour
{
    public abstract void HandleEnterLocation(IGameContext gameContext);
}
