using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SeasonManager : MonoBehaviour
{
    public SeasonManager instance {  get; private set; }

    public Seasons currentSeason;

    [SerializeField] private PostProcessVolume postProcess;
    private ColorGrading grading;

    [SerializeField] private PostProcessProfile winterProfile;
    [SerializeField] private PostProcessProfile springProfile;
    [SerializeField] private PostProcessProfile summerProfile;
    [SerializeField] private PostProcessProfile automnProfile;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSeason(Seasons.SPRING);
    }

    public void ChangeSeason(Seasons season)
    {
        currentSeason = season;
        switch(currentSeason)
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
    }


}

public enum Seasons
{
    WINTER,
    SPRING,
    SUMMER,
    AUTUMN
}