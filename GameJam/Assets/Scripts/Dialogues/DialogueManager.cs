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

    private bool updateBubblePosition;
    private Transform target;

    private List<TextQueue> queue;

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
            Debug.Log(target.name);
            bubble.transform.position = Vector2.MoveTowards(bubble.transform.position, target.position + offset, 7 * Time.deltaTime);
        }
    }

    public void AddDialogueToQueue(string dialogue, float time, Transform bubbleObjectToConnect = null)
    {
        TextQueue element = new TextQueue();
        element.time = time;
        element.text = dialogue;
        if (bubbleObjectToConnect == null)
            element.target = player;
        else
            element.target = bubbleObjectToConnect;

        queue.Add(element);


        //bubble.SetActive(true);
        //bubbleDialogue.text = dialogue;
        //if(bubbleObjectToConnect != null)
        //{
        //    target = bubbleObjectToConnect;
        //}
        //else
        //{
        //    target = player;
        //}

        //StartCoroutine(DisableTextAfterTime(time));
    }

    private void CheckQueue()
    {

    }

    IEnumerator DisableTextAfterTime(float time)
    {
        updateBubblePosition = true;
        

        yield return new WaitForSeconds(time);

        updateBubblePosition = false;
        bubble.SetActive(false);
    }

    public bool isBubbleActive()
    {
        return bubble.activeSelf;
    }
}

public struct TextQueue
{
    public string text;
    public float time;
    public Transform target;
}
