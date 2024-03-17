using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class River : SeasonObject
{
    [SerializeField] private Transform waterMaxLimit;
    [SerializeField] private Transform waterMinLimit;
    [SerializeField] private Transform waterNormalLimit;

    public Transform water;
    public float waterSpeed;

    Vector3 targetWaterPosition;

    public SpriteRenderer river;
    public Color normalWater;
    public Color frozenWater;

    protected override void Start()
    {
        targetWaterPosition = water.position;
        ResetWater();
        base.Start();
    }

    public override void SeasonChanged(Seasons season)
    {
        switch (season)
        {
            case Seasons.SUMMER:
                DrainWater();
                river.color = normalWater;
                river.tag = "Water";
                break;

            case Seasons.WINTER:
                ResetWater();
                river.color = frozenWater;
                river.tag = "Floor";
                break;

            case Seasons.AUTUMN:
                ResetWater();
                river.color = normalWater;
                river.tag = "Water";
                break;

            case Seasons.SPRING:
                ResetWater();
                river.color = normalWater;
                river.tag = "Water";
                break;
        }
    }

    public void FillWater()
    {
        targetWaterPosition = new(targetWaterPosition.x, waterMaxLimit.position.y - (water.localScale.y/2f), targetWaterPosition.z);
    }

    public void ResetWater()
    {
        targetWaterPosition = new(targetWaterPosition.x, waterNormalLimit.position.y - (water.localScale.y / 2f), targetWaterPosition.z);
    }

    public void DrainWater()
    {
        targetWaterPosition = new(targetWaterPosition.x, waterMinLimit.position.y - (water.localScale.y / 2f), targetWaterPosition.z);
    }

    private void Update()
    {
        water.position = Vector3.MoveTowards(water.position, targetWaterPosition, Time.deltaTime * waterSpeed);

    }
}
