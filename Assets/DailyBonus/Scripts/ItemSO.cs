using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    [SerializeField] private Item _id;
    [SerializeField] private Sprite _icon;

    public Item Id => _id;
    public Sprite Icon => _icon;
}
