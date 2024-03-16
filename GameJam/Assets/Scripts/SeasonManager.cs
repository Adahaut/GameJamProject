using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager instance {  get; private set; }

    public Seasons currentSeason;

    [SerializeField] private PostProcessVolume postProcess;
    private ColorGrading grading;

    [SerializeField] private PostProcessProfile winterProfile;
    [SerializeField] private PostProcessProfile springProfile;
    [SerializeField] private PostProcessProfile summerProfile;
    [SerializeField] private PostProcessProfile automnProfile;

    public List<SeasonObject> allObjects;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSeason(Seasons.SUMMER);
    }

    public void ChangeSeason(Seasons season)
    {
        currentSeason = season;
        switch(season)
        {
            case Seasons.SPRING:
                postProcess.profile = springProfile;
                break;
            case Seasons.SUMMER:
                postProcess.profile = summerProfile;
                break;
            case Seasons.WINTER:
                postProcess.profile = winterProfile;
                break;
            case Seasons.AUTUMN:
                postProcess.profile = automnProfile;
                break;
        }

        foreach (var obj in allObjects)
        {
            obj.SeasonChanged(currentSeason);
        }
    }

    public void TornadeEvent()
    {
        Debug.Log("Tornado");
    }

    public void FloodEvent()
    {
        Debug.Log("Flood");
    }

}

public enum Seasons
{
    WINTER,
    SPRING,
    SUMMER,
    AUTUMN
}