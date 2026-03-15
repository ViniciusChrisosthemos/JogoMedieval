using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationResultView : MonoBehaviour
{
    [SerializeField] private GameObject m_view;
    [SerializeField] private TextMeshProUGUI m_txtGold;
    [SerializeField] private TextMeshProUGUI m_txtExp;
    [SerializeField] private TextMeshProUGUI m_txtPopularity;
    [SerializeField] private UIListDisplay m_itemListDisplay;
    [SerializeField] private Button m_btnOk;

    private Action m_callback;

    private void Awake()
    {
        m_btnOk.onClick.AddListener(HandleCloseScreen);
    }

    public void OpenScreen(RewardData rewardData, Action callback)
    {
        m_view.SetActive(true);

        m_txtGold.text = rewardData.Gold.ToString();
        m_txtExp.text = rewardData.Exp.ToString();
        m_txtPopularity.text = rewardData.Popularity.ToString();
        m_itemListDisplay.SetItems(rewardData.Items, null);

        m_callback = callback;
    }

    public void HandleCloseScreen()
    {
        m_view.SetActive(false);

        m_callback?.Invoke();
    }
}
