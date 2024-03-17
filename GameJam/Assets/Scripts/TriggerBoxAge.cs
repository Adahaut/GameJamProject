using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxAge : MonoBehaviour
{
    Transform targetPlayer;

    public GameObject blockGO;

    private void Start()
    {
        blockGO.SetActive(false);
    }

    public void SetNoReturn(Transform player)
    {
        targetPlayer = player;
    }

    private void Update()
    {
        if (targetPlayer == null) return;

        if(targetPlayer.transform.position.x > transform.position.x + 0.25f)
        {
            blockGO.SetActive(true);
        }
    }
}
