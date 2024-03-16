using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : SeasonObject
{
    public SpriteRenderer treeSprite;
    public Sprite treeSpriteWithLeaves;
    public Sprite treeSpriteWithoutLeaves;

    public override void SeasonChanged(string season)
    {
        switch(season)
        {
            case "summer":
                treeSprite.sprite = treeSpriteWithLeaves;
                break;

            case "winter":
                treeSprite.sprite = treeSpriteWithoutLeaves;
                break;
            
            case "fall":
                treeSprite.sprite = treeSpriteWithoutLeaves;
                break;
                
            case "spring":
                treeSprite.sprite = treeSpriteWithLeaves;
                break;  
        }
    }
}
