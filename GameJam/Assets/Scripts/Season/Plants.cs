using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Plants : SeasonObject
{
    public SpriteRenderer plants;
    public Sprite underGroundPlants;
    public Sprite growingPlants;

    public override void SeasonChanged(string season)
    {
        switch (season)
        {
            case "summer":
                plants.sprite = growingPlants;
                break;

            case "winter":
                plants.sprite = underGroundPlants;
                break;

            case "fall":
                plants.sprite = underGroundPlants;
                break;

            case "spring":
                plants.sprite = underGroundPlants;
                break;
        }
    }

}
