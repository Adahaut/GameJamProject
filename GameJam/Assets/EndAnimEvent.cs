using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndAnimEvent : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wheelSpell;
    [SerializeField] private Transform center;

    [Header("dialogue")]
    [SerializeField] private string dialogue;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float timetoShowFirstDialogue = 2f;
    [SerializeField] private Sprite firstDialogueSpriteBubble;

    [Header("dialogue2")]
    [SerializeField] private string dialogue2;
    [SerializeField] private Vector3 offset2;
    [SerializeField] private float timetoShowFirstDialogue2 = 2f;
    [SerializeField] private Sprite firstDialogueSpriteBubble2;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartEndAnim()
    {
        animator.Play("End");
    }

    public void LockMovements()
    {
        player.GetComponent<PlayerInput>().enabled = false;
        wheelSpell.GetComponent<PlayerInput>().enabled = false;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetText()
    {
        DialogueManager.instance.AddDialogueToQueue(dialogue, 5f, offset, timetoShowFirstDialogue, center, firstDialogueSpriteBubble);
    }

    public void SetText2()
    {
        DialogueManager.instance.AddDialogueToQueue(dialogue2, 3f, offset2, timetoShowFirstDialogue2, center, firstDialogueSpriteBubble2);
    }

}
