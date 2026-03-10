using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MuralView : MonoBehaviour
{
    [SerializeField] private Transform m_spotParent;
    [SerializeField] private Transform m_contractParent;
    [SerializeField] private ContractView m_contractPrefab;

    public void UpdateView(ContractManager contractManager)
    {
        m_contractParent.ClearChilds();

        int spotIndex = 0;
        foreach (var contract in contractManager.AvailableContracts)
        {
            var spotTransform = m_spotParent.GetChild(spotIndex);

            var instance = Instantiate(m_contractPrefab, spotTransform.position, spotTransform.rotation, m_contractParent);
            instance.Setup(contract, c => HandleContractAccepted(c, contractManager), c => HandleContractRefused(c, contractManager));
            instance.DisableInteraction();

            spotIndex++;
        }
    }

    private void HandleContractAccepted(BaseContractData contract, ContractManager contractManager)
    {
        contractManager.AccepContract(contract);

        UpdateView(contractManager);

        EnableConttractInteraction();
    }

    private void HandleContractRefused(BaseContractData contract, ContractManager contractManager)
    {
        contractManager.RefuseContract(contract);

        UpdateView(contractManager);

        EnableConttractInteraction();
    }

    public void DisableContractInteraction()
    {
        foreach (var contractView in m_contractParent.GetComponentsInChildren<ContractView>())
        {
            contractView.DisableInteraction();
        }
    }

    public void EnableConttractInteraction()
    {
        foreach(var contractView in m_contractParent.GetComponentsInChildren<ContractView>())
        {
            contractView.EnableInteraction();
        }
    }
}
