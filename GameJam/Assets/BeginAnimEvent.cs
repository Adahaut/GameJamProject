using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BeginAnimEvent : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private AudioSource breakGlass;
    [SerializeField] private Transform middleScreenTransform;
    [SerializeField] private Transform child;
    [SerializeField] private Transform oldMan;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spritePlayer;
    [SerializeField] private GameObject wheelSpell;
    [SerializeField] private GameObject triangle;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private Animator animator;


    [Header("1st dialogue")]
    [SerializeField] private string firstDialogue;
    [SerializeField] private Vector3 firstDialogueOffset;
    [SerializeField] private float timetoShowFirstDialogue = 3f;
    [SerializeField] private Sprite firstDialogueSpriteBubble;

    [Header("1st old man dialogue")]
    [SerializeField] private string firstOldDialogue;
    [SerializeField] private Vector3 firstOldDialogueOffset;
    [SerializeField] private float timetoShowFirstOldDialogue = 3f;
    [SerializeField] private Sprite firstOldDialogueSpriteBubble;

    [Header("1st child dialogue")]
    [SerializeField] private string firstChildDialogue;
    [SerializeField] private Vector3 firstChildDialogueOffset;
    [SerializeField] private float timetoShowFirstChildDialogue = 3f;
    [SerializeField] private Sprite firstChildDialogueSpriteBubble;

    [Header("2nd old dialogue")]
    [SerializeField] private string secondOldDialogue;
    [SerializeField] private Vector3 secondOldDialogueOffset;
    [SerializeField] private float timetoShowSecondOldDialogue = 3f;
    [SerializeField] private Sprite secondOldDialogueSpriteBubble;

    [Header("2nd child dialogue")]
    [SerializeField] private string secondChildDialogue;
    [SerializeField] private Vector3 secondChildDialogueOffset;
    [SerializeField] private float timetoShowSecondChildDialogue = 3f;
    [SerializeField] private Sprite secondChildDialogueSpriteBubble;

    [Header("3rd child dialogue")]
    [SerializeField] private string thirdChildDialogue;
    [SerializeField] private Vector3 thirdChildDialogueOffset;
    [SerializeField] private float timetoShowThirdChildDialogue = 3f;
    [SerializeField] private Sprite thirdChildDialogueSpriteBubble;

    private void Start()
    {
        animator.Play("Begin");
    }
    public void SetText()
    {
        DialogueManager.instance.AddDialogueToQueue(firstDialogue, 4f, firstDialogueOffset ,timetoShowFirstDialogue, middleScreenTransform, firstDialogueSpriteBubble);
    }

    public void SetFirstOldManText()
    {
        DialogueManager.instance.AddDialogueToQueue(firstOldDialogue, 3f, firstOldDialogueOffset, timetoShowFirstOldDialogue, oldMan.transform, firstOldDialogueSpriteBubble);
    }

    public void SetFirstChildText()
    {
        DialogueManager.instance.AddDialogueToQueue(firstChildDialogue, 4f, firstChildDialogueOffset, timetoShowFirstChildDialogue, child.transform, firstChildDialogueSpriteBubble);
    }

    public void SetSecondOldManText()
    {
        DialogueManager.instance.AddDialogueToQueue(secondOldDialogue, 4f, secondOldDialogueOffset, timetoShowSecondOldDialogue, oldMan.transform, secondOldDialogueSpriteBubble);
    }

    public void SetSecondChildText()
    {
        DialogueManager.instance.AddDialogueToQueue(secondChildDialogue, 5f, secondChildDialogueOffset, timetoShowSecondChildDialogue, child.transform, secondChildDialogueSpriteBubble);
    }

    public void SetThirdChildText()
    {
        DialogueManager.instance.AddDialogueToQueue(thirdChildDialogue, 5f, thirdChildDialogueOffset, timetoShowThirdChildDialogue, child.transform, thirdChildDialogueSpriteBubble);
    }

    public void PlayAudioGlass()
    {
        breakGlass.Play();
    }

    public void FlipChild()
    {
        child.localScale = new Vector3(child.localScale.x * -1, child.localScale.y, child.localScale.z);
    }

    public void DisablePlayer()
    {
        player.GetComponent<PlayerInput>().enabled = false;
        wheelSpell.GetComponent<PlayerInput>().enabled = false;
        //spritePlayer.SetActive(false);
    }

    public void EnablePlayer()
    {
        blackScreen.GetComponent<Image>().enabled = false;
        spritePlayer.SetActive(true);
        player.GetComponent<PlayerInput>().enabled = true;
        wheelSpell.GetComponent<PlayerInput>().enabled = true;
        player.transform.position = child.transform.position;
        player.transform.position = new(player.transform.position.x, player.transform.position.y, 0);
    }
}
