using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : UIItemController
{
    [SerializeField] private Image m_itemIcon;
    [SerializeField] private TextMeshProUGUI m_itemAmount;
    [SerializeField] private GameObject m_amountParent;

    protected override void HandleInit(object obj)
    {
        var itemHolder = obj as ItemHolder;

        m_itemIcon.sprite = itemHolder.Item.Icon;
        m_itemAmount.text = itemHolder.Amount.ToString();

        m_amountParent.SetActive(itemHolder.Amount > 1);
    }
}
