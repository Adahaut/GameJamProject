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

    public override void SeasonChanged(string season)
    {
        switch(season)
        {
            case "summer":
                treeSprite.sprite = treeSpriteWithLeaves;
                leaf.SetActive(false);
                break;

            case "winter":
                treeSprite.sprite = treeSpriteWithoutLeaves;
                leaf.SetActive(false);
                break;
            
            case "fall":
                treeSprite.sprite = treeSpriteWithoutLeaves;
                leaf.SetActive(true);
                break;
                
            case "spring":
                treeSprite.sprite = treeSpriteWithLeaves;
                leaf.SetActive(false);
                break;  
        }
    }
}
