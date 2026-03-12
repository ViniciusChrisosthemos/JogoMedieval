using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestView : UIItemController
{
    [SerializeField] private RectTransform m_mainRectTransform;
    [SerializeField] private TextMeshProUGUI m_txtQuestTitle;
    [SerializeField] private TextMeshProUGUI m_txtQuestDescription;
    [SerializeField] private Button m_btnToggleVisibility;

    [SerializeField] private float m_titleTextHeight = 60;
    [SerializeField] private float m_descriptionTextHeight = 33;

    private bool m_showDescription = false;
    private BaseContractData m_contractData;

    private void Awake()
    {
        m_btnToggleVisibility.onClick.AddListener(ToggleVisibility);
    }

    protected override void HandleInit(object obj)
    {
        m_contractData = obj as BaseContractData;

        UpdateUI();
    }

    public void ToggleVisibility()
    {
        m_showDescription = !m_showDescription;

        UpdateUI();
    }

    private void UpdateUI()
    {
        m_txtQuestTitle.text = m_contractData.Title;
        m_txtQuestDescription.text = m_contractData.GetDescription();

        m_txtQuestDescription.gameObject.SetActive(m_showDescription);

        var height = m_titleTextHeight;

        if (m_showDescription)
        {
            m_txtQuestDescription.ForceMeshUpdate();

            var descriptionHeight = m_txtQuestDescription.preferredHeight;
            height += descriptionHeight;

            Debug.Log($"{descriptionHeight} {m_descriptionTextHeight}");

            m_txtQuestDescription.rectTransform.sizeDelta = new Vector2(m_txtQuestDescription.rectTransform.sizeDelta.x, descriptionHeight);
        }

        m_mainRectTransform.sizeDelta = new Vector2(m_mainRectTransform.sizeDelta.x, height);
    }
}
