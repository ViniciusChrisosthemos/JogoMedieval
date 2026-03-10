using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemContractData : BaseContractData
{
    private const string BAD_FORMAT_STRING = "ERROR:BAD_FORMAT_STRING";

    public List<ObjectAmountData<BaseItem>> RequiredItems {  get; private set; }

    public CollectItemContractData(string title, string baseDescription, RewardData rewardData, List<ObjectAmountData<BaseItem>> requiredItens) : base(title, baseDescription, rewardData)
    {
        RequiredItems = requiredItens;
    }

    public override bool CheckConditions(IGameContext gameContext)
    {
        var invetoryManager = gameContext.GetReference<InventoryManager>();

        foreach (var requiredItemData in RequiredItems)
        {
            var itemCount = invetoryManager.GetItemCount(requiredItemData.Object.ID);

            if (itemCount < requiredItemData.amount) return false;
        }

        return true;
    }

    public override string GetDescription()
    {
        var pattern = @"<(\d+),(object|amount)>";
        var description = TextParser.ParseText(BaseDescription, pattern, (data) =>
        {
            var splittedString = data.Replace("<", "").Replace(">", "").Split(',');

            var index = int.Parse(splittedString[0]);
            var infoType = splittedString[1];

            if (index >= RequiredItems.Count) return BAD_FORMAT_STRING;

            switch(infoType)
            {
                case "amount": return RequiredItems[index].amount.ToString();
                case "object": return RequiredItems[index].Object.Name;
                default: return BAD_FORMAT_STRING;
            }
        });

        return description;
    }
}
