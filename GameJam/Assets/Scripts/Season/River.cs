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
                river.tag = "Water";
                DrainWater();
                river.color = normalWater;
                break;

            case Seasons.WINTER:
                river.tag = "Floor";
                ResetWater();
                river.color = frozenWater;
                break;

            case Seasons.AUTUMN:
                river.tag = "Water";
                ResetWater();
                river.color = normalWater;
                break;

            case Seasons.SPRING:
                river.tag = "Water";
                ResetWater();
                river.color = normalWater;
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
