using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            GetComponentInParent<PlayerMovement>()._canWallJumpL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            GetComponentInParent<PlayerMovement>()._canWallJumpL = false;
        }
    }
}
