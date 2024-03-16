using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            GetComponentInParent<PlayerMovement>()._grounded = true;
            GetComponentInParent<PlayerMovement>().IsGrounded();
        }
        else if (collision.tag == "Water")
        {
            GetComponentInParent<PlayerMovement>().EnterWater();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            GetComponentInParent<PlayerMovement>()._grounded = false;
        }
        else if (collision.tag == "Water")
        {
            GetComponentInParent<PlayerMovement>().ExitWater();
        }
    }
}
