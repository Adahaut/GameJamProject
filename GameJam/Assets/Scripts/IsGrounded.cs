using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    PlayerMovement _pM;

    private void Start()
    {
        _pM = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            _pM._grounded = true;
            _pM.IsGrounded();
        }
        else if (collision.tag == "Water")
        {
            _pM.EnterWater();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            _pM._grounded = false;
        }
        else if (collision.tag == "Water")
        {
            _pM.ExitWater();
        }
    }
}
