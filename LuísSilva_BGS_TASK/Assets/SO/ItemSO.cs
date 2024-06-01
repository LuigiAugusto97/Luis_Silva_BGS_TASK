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

    [SerializeField] Sprite[] upSprites;
    [SerializeField] Sprite[] downSprites;
    [SerializeField] Sprite[] leftSprites;
    [SerializeField] Sprite[] rightSprites;
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
    public Sprite[] UpSprites
    {
        get { return upSprites; }
    }
    public Sprite[] DownSprites
    {
        get { return downSprites; }
    }
    public Sprite[] LeftSprites
    {
        get { return leftSprites; }
    }
    public Sprite[] RightSprites
    {
        get { return rightSprites; }
    }
}

public enum ItemType
{
    Head,Body
}