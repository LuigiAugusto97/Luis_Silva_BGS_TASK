using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Boolean to handle the camera following the player;
    [SerializeField] bool CanFollow = true;

    //Reference to the player
    private Player_CTRL _player;
    private void Awake()
    {
        _player = FindObjectOfType<Player_CTRL>();
    }
    void Update()
    {
        if (CanFollow)
        {
            //Equal the position of the camera to the position of the player
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        }
    }
}
