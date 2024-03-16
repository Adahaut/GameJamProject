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

    private void Start()
    {
        targetWaterPosition = water.position;
        ResetWater();
    }

    public override void SeasonChanged(string season)
    {
        switch (season)
        {
            case "summer":
                river.sprite = NoRiver;
                break;

            case "winter":
                river.sprite = freezeRiver;
                break;

            case "fall":
                river.sprite = fullRiver;
                break;

            case "spring":
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
