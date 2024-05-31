using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item SO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] Sprite _icon;
    [SerializeField] ItemType _type;
    [SerializeField] float _price;
    public string Name
    {
        get { return _name; }
    }
    public Sprite Icon
    {
        get { return _icon; }
    }
    public ItemType Type
    {
        get { return _type; }
    }
    public float Price
    {
        get { return _price; }
    }
}

public enum ItemType
{
    Head,Body
}