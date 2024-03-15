using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string dialogue;
    [SerializeField] private Transform connectedObjectToBubble;
    [SerializeField] private float timeToDisplayText;
    private bool opened = false;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opened)
        {
            opened = true;
            DialogueManager.instance.AddDialogueToQueue(dialogue, timeToDisplayText, connectedObjectToBubble);
        }
        
    }
}
