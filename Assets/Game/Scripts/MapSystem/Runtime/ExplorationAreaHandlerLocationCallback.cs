using UnityEngine;

public class ExplorationAreaHandlerLocationCallback : AbstractLocationCallback
{
    public override void HandleEnterLocation(IGameContext gameContext)
    {
        var uiManager = gameContext.GetReference<UIManager>();

        uiManager.OpenExplorationView();
    }

    public override void HandleExitLocation(IGameContext gameContext)
    {
        var uiManager = gameContext.GetReference<UIManager>();

        uiManager.CloseExplorationView();
    }
}
