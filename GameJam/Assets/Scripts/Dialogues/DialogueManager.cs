using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI bubbleDialogue;
    [SerializeField] private GameObject bubble;

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float timeToWriteTexts;

    private bool updateBubblePosition;
    private Transform target;

    private List<TextQueue> queue = new List<TextQueue>();

    public static DialogueManager instance {  get; private set; }

    private void Awake()
    {
        instance = this;
        bubble.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(updateBubblePosition)
        {
            bubble.transform.position = Vector2.MoveTowards(bubble.transform.position, target.position + offset, 7 * Time.deltaTime);
        }
    }

    public void AddDialogueToQueue(string dialogue, float time, Vector3 _offset, float timeToShow, Transform bubbleObjectToConnect = null)
    {
        offset = _offset;
        timeToWriteTexts = timeToShow;
        TextQueue element = new TextQueue();
        element.time = time;
        element.text = dialogue;
        if (bubbleObjectToConnect == null)
            element.target = player;
        else
            element.target = bubbleObjectToConnect;

        queue.Add(element);
        if(!bubble.activeSelf)
            CheckQueue();
    }

    private void CheckQueue()
    {
        if(queue.Count != 0)
        {
            if (!bubble.activeSelf)
                bubble.transform.position = queue[0].target.position + offset;
            bubble.SetActive(true);
            StartCoroutine(ShowLetters(queue[0].text));
            target = queue[0].target;
            StartCoroutine(DisableTextAfterTime(queue[0].time));
            queue.Remove(queue[0]);

        }
    }

    IEnumerator DisableTextAfterTime(float time)
    {
        updateBubblePosition = true;
        

        yield return new WaitForSeconds(time);

        updateBubblePosition = false;
        bubble.GetComponent<Bubble>().Disable();
        CheckQueue();
    }

    IEnumerator ShowLetters(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            bubbleDialogue.text = text.Substring(0, i + 1);
            yield return new WaitForSeconds(timeToWriteTexts / (float)text.Length);
        }
    }
}

public struct TextQueue
{
    public string text;
    public float time;
    public Transform target;
}
