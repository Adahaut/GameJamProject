using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] PlayerInput playerInput;


    public int ageState = 0;

    public List<Sprite> spriteStatePlayer = new();

    private void Start()
    {
        playerMovement._spriteRenderer.sprite = spriteStatePlayer[ageState];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "TriggerAgeUp")
        {
            if (ageState + 1 >= spriteStatePlayer.Count)
            {
                return;
            }
            Destroy(collision.gameObject);
            AgeUp();
        }
        else if(collision.tag == "TriggerEventCamera")
        {
            playerInput.enabled = false;
            CinematicParameters parameters = collision.GetComponent<CinematicParameters>();
            cameraManager.FollowTarget(parameters.target, parameters.time);
            Invoke("EndFollowTarget", parameters.time);
            Destroy(collision.gameObject);
        }
    }

    private void EndFollowTarget()
    {
        cameraManager.EndFollow();
        playerInput.enabled = true;
    }

    private void AgeUp()
    {
        print("aaa");
        ageState++;
        playerMovement._spriteRenderer.sprite = spriteStatePlayer[ageState];
        if (ageState == 2)
        {
            playerMovement._jumpMax = 1;
            playerMovement.WC1.SetActive(false);
            playerMovement.WC2.SetActive(false);
        }
    }
}
