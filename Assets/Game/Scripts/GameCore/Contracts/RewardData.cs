using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RewardData
{
    public int Gold {  get; private set; }
    public int Exp { get; private set; }
    public int Popularity { get; private set; }
    public List<ItemHolder> Items { get; private set; }

    public RewardData(int gold, int exp, int popularity, List<ItemHolder> items)
    {
        Gold = gold; 
        Exp = exp;
        Popularity = popularity;
        Items = items;
    }
}
