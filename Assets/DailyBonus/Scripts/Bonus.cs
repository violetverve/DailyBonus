using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DailyBonus.Inventory;

namespace DailyBonus
{
    [Serializable]
    public class Bonus
    {
        private readonly int _day;
        private readonly string _name;
        private readonly int _quantity;
        private Item _id;

        public int Day => _day;
        public string Name => _name;
        public int Quantity => _quantity;
        public Item Id => _id;

        public Bonus(int day, string name, int quantity)
        {
            _day = day;
            _name = name;
            _quantity = quantity;
        }

        public void SetItemId(Item id)
        {
            _id = id;
        }
    }
}
