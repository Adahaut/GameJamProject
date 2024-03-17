using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<string> dialogues;
    [SerializeField] private Transform connectedObjectToBubble;
    [SerializeField] private float timeToDisplayText;
    private bool opened = false;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float timeToShowText = 3f;
    [SerializeField] private Sprite sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opened)
        {
            opened = true;
            foreach(string dialogue in dialogues)
            {
                DialogueManager.instance.AddDialogueToQueue(dialogue, timeToDisplayText, offset, timeToShowText, connectedObjectToBubble, sprite);
            }
        }
        
    }
}
