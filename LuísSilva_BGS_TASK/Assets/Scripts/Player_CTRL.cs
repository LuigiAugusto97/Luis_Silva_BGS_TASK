using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_CTRL : MonoBehaviour
{
    //References to the rigid body and the animator components of the player; 
    private Rigidbody2D _rb;
    private Animator _anim;

    [Header("Speed of the player")]
    [SerializeField] float Speed;

    //Booleans to handle in animation of the player is moving and if can move at all
    private bool _canMove = false;
    private bool _isMoving;
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    //Vectors to handle where the player is heading and the last direction it went to 
    private Vector2 _dirVector;
    private Vector2 _lasDirVector;

    [Header("Layer which the player can interact with")]
    [SerializeField] LayerMask interactLayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        //force Down pose on Start
        _anim.SetFloat("LastVerticalMov", -1);
    }

    //Function that permits the player to search somethin to interact with
    public void Interact()
    {
        Vector2 interactPos = _rb.position + _lasDirVector;
        //Debug.DrawLine(transform.position, interactPos, Color.red, 0.5f);
        //Check for collider with the mask to interact
        var collider = Physics2D.OverlapCircle(interactPos, .3f, interactLayer);
        if (collider != null)
        {
            Debug.Log("Has collider", collider);
            //Apply the interact function for the object
            collider.GetComponent<IInteractables>()?.Interact();
        }
    }

    //Function handle players movement
    public void HandleMovement(bool canMove)
    {
        //Catch reference of the boolean that says is the player can move, and sends the paramete to the animator
        CanMove = canMove;
        _anim.SetBool("CanMove", CanMove);

        //Catch the inputs of the player
        float moveInput_x = Input.GetAxisRaw("Horizontal");
        float moveInput_y = Input.GetAxisRaw("Vertical");

        //If is it allowed to move apply forces and send the parameters to the animator, else stop moving
        if (CanMove)
        {
            _dirVector = new Vector2(moveInput_x, moveInput_y);
            _rb.velocity = _dirVector * Speed;
            _anim.SetFloat("HorizontalMovement", moveInput_x);
            if (moveInput_x == 0)
            {
                _anim.SetFloat("VerticalMovement", moveInput_y);
            }
            else
            {
                _anim.SetFloat("VerticalMovement", 0);
            }
           

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
