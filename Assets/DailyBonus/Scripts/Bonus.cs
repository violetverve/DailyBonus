using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Bonus
{
    private readonly int _day;
    private readonly string _id; // change to id (enum)
    private readonly int _quantity;
    public ItemSO bonusItem;

    public int Day => _day;
    public string Id => _id;
    public int Quantity => _quantity;

    public Bonus(int day, string id, int quantity)
    {
        _day = day;
        _id = id;
        _quantity = quantity;
    }
}
