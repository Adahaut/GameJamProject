using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Plants : SeasonObject
{
    public GameObject liane;

    public override void SeasonChanged(Seasons season)
    {
        switch (season)
        {
            case Seasons.SUMMER:
                liane.SetActive(false);
                break;

            case Seasons.WINTER:
                liane.SetActive(false);
                break;

            case Seasons.AUTUMN:
                liane.SetActive(false);
                break;

            case Seasons.SPRING:
                liane.SetActive(true);
                break;
        }
    }

}
