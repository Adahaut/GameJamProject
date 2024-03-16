using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckL : MonoBehaviour
{
    PlayerMovement _pM;

    private void Start()
    {
        _pM = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            _pM._canWallJumpL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            _pM._canWallJumpL = false;
        }
    }
}
