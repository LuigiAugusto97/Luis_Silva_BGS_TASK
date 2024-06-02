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
    [SerializeField] Sprite[] UpSprites;
    [SerializeField] Sprite[] DownSprites;
    [SerializeField] Sprite[] LeftSprites;
    [SerializeField] Sprite[] RightSprites;

    //Reference to the reference of components needed
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        //force Down pose on Start
        _anim.SetFloat("LastVerticalMov", -1);
    }

    //Funtions that handle the animation events getting the selected sprite to animate
    public void GetUpSprites(int index)
    {
        if (UpSprites.Length == 0 || index >= UpSprites.Length)
        {
            _spriteRenderer.sprite = null;
            return;
        }
        _spriteRenderer.sprite = UpSprites[index];
    }
    public void GetDownSprites(int index)
    {
        if (DownSprites.Length == 0 || index >= DownSprites.Length)
        {
            _spriteRenderer.sprite = null;
            return;
        }
        _spriteRenderer.sprite = DownSprites[index];
    }
    public void GetLeftSprites(int index)
    {
        if (LeftSprites.Length == 0 || index >= LeftSprites.Length)
        {
            _spriteRenderer.sprite = null;
            return;
        }
        _spriteRenderer.sprite = LeftSprites[index];
    }
    public void GetRightSprites(int index)
    {
        if (RightSprites.Length == 0 || index >= RightSprites.Length)
        {
            _spriteRenderer.sprite = null;
            return;
        }
        _spriteRenderer.sprite = RightSprites[index];
    }

    //Funtion to change the sprites needed to animate to the current equiped item
    public void ChangeParts(ItemData itemToChangeTo)
    {
        if (itemToChangeTo.Item.Type != bodyPart) return;

        UpSprites = itemToChangeTo.Item.UpSprites;
        DownSprites = itemToChangeTo.Item.DownSprites;
        LeftSprites = itemToChangeTo.Item.LeftSprites;
        RightSprites = itemToChangeTo.Item.RightSprites;

        _spriteRenderer.sprite = DownSprites[0];
    }

    //Function handle players movement
    public void HandleMovement(bool canMove)
    {
        //Catch reference of the boolean that says is the player can move, and sends the paramete to the animator
        _anim.SetBool("CanMove", canMove);

        //Catch the inputs of the player
        float moveInput_x = Input.GetAxisRaw("Horizontal");
        float moveInput_y = Input.GetAxisRaw("Vertical");

        //Send the parameters to the animator acording to the inputs
        if (canMove)
        {

            _anim.SetFloat("HorizontalMovement", moveInput_x);

            _anim.SetFloat("VerticalMovement", moveInput_y);


            bool _isMoving = moveInput_x != 0 || moveInput_y != 0;
            _anim.SetBool("IsMoving", _isMoving);

            if (moveInput_x != 0 || moveInput_y != 0)
            {

                _anim.SetFloat("LastHorizontalMov", moveInput_x);

                _anim.SetFloat("LastVerticalMov", moveInput_y);

            }
        }

    }

}
