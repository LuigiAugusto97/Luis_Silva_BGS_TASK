using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_CTRL : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;

    [SerializeField] float Speed;
    private Vector2 _dirVector;
    private Vector2 _lasDirVector;

    [SerializeField] LayerMask interactLayer;

    private bool _canMove = true;
    private bool _isMoving;
    
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        Vector2 interactPos = _rb.position + _lasDirVector;
        Debug.DrawLine(transform.position, interactPos, Color.red, 0.5f);
        //Check for collider with the mask to interact
        var collider = Physics2D.OverlapCircle(interactPos, .3f, interactLayer);
        if (collider != null)
        {
            Debug.Log("Has collider", collider);
            //Apply the interact function for the object
            collider.GetComponent<IInteractables>()?.Interact();
        }
    }

    public void HandleMovement(bool canMove)
    {
        CanMove = canMove;
        _anim.SetBool("CanMove", CanMove);


        float moveInput_x = Input.GetAxisRaw("Horizontal");
        float moveInput_y = Input.GetAxisRaw("Vertical");

        if (CanMove)
        {
            _dirVector = new Vector2(moveInput_x, moveInput_y);
            _rb.velocity = _dirVector * Speed;
            _anim.SetFloat("HorizontalMovement", moveInput_x);
            _anim.SetFloat("VerticalMovement", moveInput_y);

            _isMoving = moveInput_x != 0 || moveInput_y != 0;
            _anim.SetBool("IsMoving", _isMoving);

            if (moveInput_x != 0 || moveInput_y != 0)
            {
                _lasDirVector = new Vector2(moveInput_x, moveInput_y).normalized;
                _anim.SetFloat("LastHorizontalMov", moveInput_x);
                _anim.SetFloat("LastVerticalMov", moveInput_y);
            }
        }
        else
        {
            _rb.velocity = new Vector2(0,0);
        }


    }

 
}
