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
    public Sprite freezeRiver;
    public Sprite fullRiver;
    public Sprite NoRiver;

    protected override void Start()
    {
        base.Start();
        targetWaterPosition = water.position;
        ResetWater();
    }

    public override void SeasonChanged(Seasons season)
    {
        switch (season)
        {
            case Seasons.SUMMER:
                DrainWater();
                river.sprite = NoRiver;
                break;

            case Seasons.WINTER:
                ResetWater();
                river.sprite = freezeRiver;
                break;

            case Seasons.AUTUMN:
                ResetWater();
                river.sprite = fullRiver;
                break;

            case Seasons.SPRING:
                FillWater();
                river.sprite = fullRiver;
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


        if (Input.GetKeyDown(KeyCode.Y))
        {
            FillWater();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ResetWater();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            DrainWater();
        }
    }
}
