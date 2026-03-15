using UnityEngine;

public class ItemHolder
{
    public BaseItem Item {  get; private set; }
    public int Amount { get; private set; }

    public ItemHolder(BaseItem item, int amount)
    {
        Item = item;
        Amount = amount;
    }
}
