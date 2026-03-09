using UnityEngine;

public class CameraHandlerLocationCallback : AbstractLocationCallback
{
    [SerializeField] private Transform m_cameraPivot;

    public override void HandleEnterLocation(IGameContext gameContext)
    {
        var cameraManager = gameContext.GetReference<CameraManager>();
        
        cameraManager.MoveCamera(m_cameraPivot.position, m_cameraPivot.rotation);
    }

    public override void HandleExitLocation(IGameContext gameContext)
    {
        return;
    }
}
