using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Spike : SeasonObject
{
    public SpriteRenderer spike;
    public Sprite spikeUnderLeaves;
    public Sprite spikeWithoutLeaves;

    public override void SeasonChanged(string season)
    {
        switch (season)
        {
            case "summer":
                spike.sprite = spikeWithoutLeaves;
                break;

            case "winter":
                spike.sprite = spikeWithoutLeaves;
                break;

            case "fall":
                spike.sprite = spikeUnderLeaves;
                break;

            case "spring":
                spike.sprite = spikeWithoutLeaves;
                break;
        }
    }
}
