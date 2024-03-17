using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wine : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>()._winesClimbing = true;
            collision.GetComponent<PlayerMovement>().EnterWines();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>()._winesClimbing = false;
            collision.GetComponent<PlayerMovement>().ExitWines();
        }
    }
}
