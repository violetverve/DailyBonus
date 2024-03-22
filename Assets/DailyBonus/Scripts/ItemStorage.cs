using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private List<ItemSO> _items;

    public List<ItemSO> Items => _items;

    public ItemSO GetItemById(Item id)
    {
        return _items.Find(item => item.Id == id);
    }
}
