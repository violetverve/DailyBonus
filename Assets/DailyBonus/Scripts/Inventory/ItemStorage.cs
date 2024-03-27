using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DailyBonus.Inventory
{
    [CreateAssetMenu(fileName = "ItemStorage", menuName = "DailyBonus/Inventory/ItemStorage")]
    public class ItemStorageSO : ScriptableObject
    {
        [SerializeField] private List<ItemSO> _items;

        public List<ItemSO> Items => _items;

        public ItemSO GetItemById(Item id)
        {
            return _items.Find(item => item.Id == id);
        }
    }
}