using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Plants : SeasonObject
{
    public SpriteRenderer plants;
    public Sprite underGroundPlants;
    public Sprite growingPlants;

    public override void SeasonChanged(Seasons season)
    {
        switch (season)
        {
            case Seasons.SUMMER:
                plants.sprite = growingPlants;
                break;

            case Seasons.WINTER:
                plants.sprite = underGroundPlants;
                break;

            case Seasons.AUTUMN:
                plants.sprite = underGroundPlants;
                break;

            case Seasons.SPRING:
                plants.sprite = underGroundPlants;
                break;
        }
    }

}
