using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckR : MonoBehaviour
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
            _pM._canWallJumpR = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            _pM._canWallJumpR = false;
        }
    }
}
