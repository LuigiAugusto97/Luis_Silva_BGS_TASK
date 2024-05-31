using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private PlayerMovement _player;

    [SerializeField] bool CanFollow = true;
    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (CanFollow)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        }
    }
}
