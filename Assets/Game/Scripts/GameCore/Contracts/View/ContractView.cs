using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_txtTitle;
    [SerializeField] private TextMeshProUGUI m_txtDescription;
    [SerializeField] private GameObject m_buttonsParent;
    [SerializeField] private Button m_btnRefuse;
    [SerializeField] private Button m_btnAccept;

    public void Setup(BaseContractData contractData, Action<BaseContractData> onAccept, Action<BaseContractData> onRefuse)
    {
        m_txtTitle.text = contractData.Title;
        m_txtDescription.text = contractData.GetDescription();

        m_btnAccept.onClick.AddListener(() => onAccept?.Invoke(contractData));
        m_btnRefuse.onClick.AddListener(() => onRefuse?.Invoke(contractData));
    }

    public void DisableInteraction()
    {
        m_buttonsParent.SetActive(false);
    }

    public void EnableInteraction()
    {
        m_buttonsParent.SetActive(true);
    }
}
