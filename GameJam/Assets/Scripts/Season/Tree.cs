using UnityEngine;

public class Tree : SeasonObject
{
    public SpriteRenderer treeSprite;
    public Sprite treeSpriteWithLeaves;
    public Sprite treeSpriteWithoutLeaves;

    public GameObject leaves;

    private void Awake()
    {
        leaves.SetActive(false);
    }

    public override void SeasonChanged(Seasons season)
    {
        switch(season)
        {
            case Seasons.SUMMER:
                treeSprite.sprite = treeSpriteWithLeaves;
                leaves.SetActive(false);
                break;

            case Seasons.WINTER:
                treeSprite.sprite = treeSpriteWithoutLeaves;
                leaves.SetActive(false);
                break;
            
            case Seasons.AUTUMN:
                treeSprite.sprite = treeSpriteWithoutLeaves;
                leaves.SetActive(true);
                break;
                
            case Seasons.SPRING:
                treeSprite.sprite = treeSpriteWithLeaves;
                leaves.SetActive(false);
                break;  
        }
    }

    public void GrowPlant()
    {

    }
}
