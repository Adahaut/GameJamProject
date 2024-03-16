using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckR : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            GetComponentInParent<PlayerMovement>()._canWallJumpR = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            GetComponentInParent<PlayerMovement>()._canWallJumpR = false;
        }
    }
}
