using UnityEngine;

public class UIQuestManagerView : MonoBehaviour
{
    [SerializeField] private UIListDisplay m_questListDisplay;
    
    public void Setup(GameManager gameManager)
    {
        var gameContext = gameManager.GameContext;

        var contractManager = gameContext.GetReference<ContractManager>();

        contractManager.OnContractAdded += HandleContractAdded;

        m_questListDisplay.SetItems(contractManager.OngoingContracts, null);
    }

    private void HandleContractAdded(BaseContractData contractData)
    {
        m_questListDisplay.AddItem(contractData, null);
    }
}
