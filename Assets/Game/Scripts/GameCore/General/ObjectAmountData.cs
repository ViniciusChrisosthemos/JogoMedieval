using System;
using UnityEngine;

[Serializable]
public class ObjectAmountData<T>
{
    [SerializeField] private T m_object;
    [SerializeField] private int m_amount;

    public T Object => m_object;
    public int amount => m_amount;
}
