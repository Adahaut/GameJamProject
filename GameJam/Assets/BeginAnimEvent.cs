using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginAnimEvent : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private AudioSource breakGlass;
    [SerializeField] private Transform middleScreenTransform;
    [SerializeField] private Transform child;
    [SerializeField] private Transform oldMan;

    [Header("1st dialogue")]
    [SerializeField] private string firstDialogue;
    [SerializeField] private Vector3 firstDialogueOffset;
    [SerializeField] private float timetoShowFirstDialogue = 3f;

    [Header("1st old man dialogue")]
    [SerializeField] private string firstOldDialogue;
    [SerializeField] private Vector3 firstOldDialogueOffset;
    [SerializeField] private float timetoShowFirstOldDialogue = 3f;

    [Header("1st child dialogue")]
    [SerializeField] private string firstChildDialogue;
    [SerializeField] private Vector3 firstChildDialogueOffset;
    [SerializeField] private float timetoShowFirstChildDialogue = 3f;

    [Header("2nd old dialogue")]
    [SerializeField] private string secondOldDialogue;
    [SerializeField] private Vector3 secondOldDialogueOffset;
    [SerializeField] private float timetoShowSecondOldDialogue = 3f;

    [Header("2nd child dialogue")]
    [SerializeField] private string secondChildDialogue;
    [SerializeField] private Vector3 secondChildDialogueOffset;
    [SerializeField] private float timetoShowSecondChildDialogue = 3f;

    [Header("3rd child dialogue")]
    [SerializeField] private string thirdChildDialogue;
    [SerializeField] private Vector3 thirdChildDialogueOffset;
    [SerializeField] private float timetoShowThirdChildDialogue = 3f;

    public void SetText()
    {
        DialogueManager.instance.AddDialogueToQueue(firstDialogue, 4f, firstDialogueOffset ,timetoShowFirstDialogue, middleScreenTransform);
    }

    public void SetFirstOldManText()
    {
        DialogueManager.instance.AddDialogueToQueue(firstOldDialogue, 3f, firstOldDialogueOffset, timetoShowFirstOldDialogue, oldMan.transform);
    }

    public void SetFirstChildText()
    {
        DialogueManager.instance.AddDialogueToQueue(firstChildDialogue, 4f, firstChildDialogueOffset, timetoShowFirstChildDialogue, child.transform);
    }

    public void SetSecondOldManText()
    {
        DialogueManager.instance.AddDialogueToQueue(secondOldDialogue, 4f, secondOldDialogueOffset, timetoShowSecondOldDialogue, oldMan.transform);
    }

    public void SetSecondChildText()
    {
        DialogueManager.instance.AddDialogueToQueue(secondChildDialogue, 5f, secondChildDialogueOffset, timetoShowSecondChildDialogue, child.transform);
    }

    public void SetThirdChildText()
    {
        DialogueManager.instance.AddDialogueToQueue(thirdChildDialogue, 5f, thirdChildDialogueOffset, timetoShowThirdChildDialogue, child.transform);
    }

    public void PlayAudioGlass()
    {
        breakGlass.Play();
    }

    public void FlipChild()
    {
        child.localScale = new Vector3(child.localScale.x * -1, child.localScale.y, child.localScale.z);
    }
}
