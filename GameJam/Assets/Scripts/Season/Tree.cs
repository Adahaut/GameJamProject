using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : SeasonObject
{
    public SpriteRenderer treeSprite;
    public Sprite treeSpriteWithLeaves;
    public Sprite treeSpriteWithoutLeaves;

    public GameObject leaf;

    private void Awake()
    {
        leaf.SetActive(false);
    }

    public override void SeasonChanged(Seasons season)
    {
        switch(season)
        {
            case Seasons.SUMMER:
                treeSprite.sprite = treeSpriteWithLeaves;
                leaf.SetActive(false);
                break;

            case Seasons.WINTER:
                treeSprite.sprite = treeSpriteWithoutLeaves;
                leaf.SetActive(false);
                break;
            
            case Seasons.AUTUMN:
                treeSprite.sprite = treeSpriteWithoutLeaves;
                leaf.SetActive(true);
                break;
                
            case Seasons.SPRING:
                treeSprite.sprite = treeSpriteWithLeaves;
                leaf.SetActive(false);
                break;  
        }
    }

    public void GrowPlant()
    {

    }
}
