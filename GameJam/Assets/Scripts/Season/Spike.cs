using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Spike : SeasonObject
{
    public Sprite spikeUnderLeaves;
    public Sprite spikeWithoutLeaves;

    List<GameObject> spikes = new();

    protected override void Start()
    {
        foreach (Transform item in transform)
        {
            spikes.Add(item.gameObject);
        }

        base.Start();
    }

    public override void SeasonChanged(Seasons season)
    {
        switch (season)
        {
            case Seasons.SUMMER:
                ResetSpikes();
                break;

            case Seasons.WINTER:
                ResetSpikes();
                break;

            case Seasons.AUTUMN:
                CoverSpikes();
                break;

            case Seasons.SPRING:
                ResetSpikes();
                break;
        }
    }

    private void ResetSpikes()
    {
        foreach (var item in spikes)
        {
            item.tag = "Spike";
            item.GetComponent<SpriteRenderer>().sprite = spikeWithoutLeaves;
        }
    }

    private void CoverSpikes()
    {
        foreach (var item in spikes)
        {
            item.tag = "Floor";
            item.GetComponent<SpriteRenderer>().sprite = spikeUnderLeaves;
        }
    }
}
