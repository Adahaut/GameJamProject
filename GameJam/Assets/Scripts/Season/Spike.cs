using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Spike : SeasonObject
{
    public SpriteRenderer spike;
    public Sprite spikeUnderLeaves;
    public Sprite spikeWithoutLeaves;

    public override void SeasonChanged(Seasons season)
    {
        switch (season)
        {
            case Seasons.SUMMER:
                spike.sprite = spikeWithoutLeaves;
                break;

            case Seasons.WINTER:
                spike.sprite = spikeWithoutLeaves;
                break;

            case Seasons.AUTUMN:
                spike.sprite = spikeUnderLeaves;
                break;

            case Seasons.SPRING:
                spike.sprite = spikeWithoutLeaves;
                break;
        }
    }
}
