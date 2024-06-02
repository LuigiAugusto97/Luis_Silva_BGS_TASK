using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartAnimation : MonoBehaviour
{
    [Header("Type of body part that this script handles")]
    [SerializeField] ItemType bodyPart;
    public ItemType BodyPart
    {
        get { return bodyPart; }
    }

    [Header("Sprites for animation of the current equipped item")]
    [SerializeField] Sprite[] Head_UpSprites;
    [SerializeField] Sprite[] Head_DownSprites;
    [SerializeField] Sprite[] Head_LeftSprites;
    [SerializeField] Sprite[] Head_RightSprites;

    [SerializeField] Sprite[] Body_UpSprites;
    [SerializeField] Sprite[] Body_DownSprites;
    [SerializeField] Sprite[] Body_LeftSprites;
    [SerializeField] Sprite[] Body_RightSprites;

    //Reference to the reference of components needed
    [SerializeField] SpriteRenderer Head_SpriteRenderer;
    [SerializeField] SpriteRenderer Body_SpriteRenderer;

    //Funtions that handle the animation events getting the selected sprite to animate
    public void GetUpSprites_Head(int index)
    {
        if (Head_UpSprites.Length == 0 || index >= Head_UpSprites.Length)
        {
            Head_SpriteRenderer.sprite = null;
            return;
        }
        Head_SpriteRenderer.sprite = Head_UpSprites[index];
    }
    public void GetDownSprites_Head(int index)
    {
        if (Head_DownSprites.Length == 0 || index >= Head_DownSprites.Length)
        {
            Head_SpriteRenderer.sprite = null;
            return;
        }
        Head_SpriteRenderer.sprite = Head_DownSprites[index];
    }
    public void GetLeftSprites_Head(int index)
    {
        if (Head_LeftSprites.Length == 0 || index >= Head_LeftSprites.Length)
        {
            Head_SpriteRenderer.sprite = null;
            return;
        }
        Head_SpriteRenderer.sprite = Head_LeftSprites[index];
    }
    public void GetRightSprites_Head(int index)
    {
        if (Head_RightSprites.Length == 0 || index >= Head_RightSprites.Length)
        {
            Head_SpriteRenderer.sprite = null;
            return;
        }
        Head_SpriteRenderer.sprite = Head_RightSprites[index];
    } 
    public void GetUpSprites_Body(int index)
    {
        if (Body_UpSprites.Length == 0 || index >= Body_DownSprites.Length)
        {
            Body_SpriteRenderer.sprite = null;
            return;
        }
        Body_SpriteRenderer.sprite = Body_UpSprites[index];
    }
    public void GetDownSprites_Body(int index)
    {
        if (Body_DownSprites.Length == 0 || index >= Body_DownSprites.Length)
        {
            Body_SpriteRenderer.sprite = null;
            return;
        }
        Body_SpriteRenderer.sprite = Body_DownSprites[index];
    }
    public void GetLeftSprites_Body(int index)
    {
        if (Body_LeftSprites.Length == 0 || index >= Body_DownSprites.Length)
        {
            Body_SpriteRenderer.sprite = null;
            return;
        }
        Body_SpriteRenderer.sprite = Body_LeftSprites[index];
    }
    public void GetRightSprites_Body(int index)
    {
        if (Body_RightSprites.Length == 0 || index >= Body_DownSprites.Length)
        {
            Body_SpriteRenderer.sprite = null;
            return;
        }
        Body_SpriteRenderer.sprite = Body_RightSprites[index];
    }

    //Funtion to change the sprites needed to animate to the current equiped item
    public void ChangeParts(ItemData itemToChangeTo)
    {
        switch (itemToChangeTo.Item.Type)
        {
            case ItemType.Head:
                Head_UpSprites = itemToChangeTo.Item.UpSprites;
                Head_DownSprites = itemToChangeTo.Item.DownSprites;
                Head_LeftSprites = itemToChangeTo.Item.LeftSprites;
                Head_RightSprites = itemToChangeTo.Item.RightSprites;

                Head_SpriteRenderer.sprite = Head_DownSprites[0];
                break;

            case ItemType.Body:
                Body_UpSprites = itemToChangeTo.Item.UpSprites;
                Body_DownSprites = itemToChangeTo.Item.DownSprites;
                Body_LeftSprites = itemToChangeTo.Item.LeftSprites;
                Body_RightSprites = itemToChangeTo.Item.RightSprites;

                Body_SpriteRenderer.sprite = Body_DownSprites[0];
                Debug.Log("Body sprite renderer" + Body_SpriteRenderer.sprite);
                break;
            default:
                break;
        }
    ;
    }

}
