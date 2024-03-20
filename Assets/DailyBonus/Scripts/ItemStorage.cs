using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] private List<ItemSO> _items;

    public List<ItemSO> Items => _items;

    public ItemSO GetItemById(string id)
    {
        return _items.Find(item => item.name == id);
    } 
}
