using UnityEngine;

public class GuildView : AbstractLocationCallback
{
    [SerializeField] private MuralView m_muralView;

    public override void HandleEnterLocation(IGameContext gameContext)
    {
        UpdateView();
    }

    public override void HandleExitLocation(IGameContext gameContext)
    {
    }

    public void UpdateView()
    {
        var gameContext = GameManager.Instance.GameContext;

        m_muralView.UpdateView(gameContext.GetReference<ContractManager>());
    }
}
