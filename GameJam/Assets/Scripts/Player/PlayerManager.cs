using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSprite;

    private int ageState = 0;

    public List<Sprite> spriteStatePlayer = new();

    private void Start()
    {
        playerSprite.sprite = spriteStatePlayer[ageState];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "TriggerAgeUp")
        {
            if (ageState + 1 >= spriteStatePlayer.Count)
            {
                return;
            }
            ageState++;
            playerSprite.sprite = spriteStatePlayer[ageState];
            Destroy(collision.gameObject);
        }

    }
}
