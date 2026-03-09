using UnityEngine;

public abstract class AbstractLocationCallback : MonoBehaviour
{
    public abstract void HandleEnterLocation(IGameContext gameContext);
    public abstract void HandleExitLocation(IGameContext gameContext);
}
