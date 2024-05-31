using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Player_CTRL _player;

    [SerializeField] bool CanFollow = true;
    private void Awake()
    {
        _player = FindObjectOfType<Player_CTRL>();
    }
    void Update()
    {
        if (CanFollow)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        }
    }
}
