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

    [SerializeField] private AudioSource summerSound;
    [SerializeField] private AudioSource autumnSound;
    [SerializeField] private AudioSource springSound;
    [SerializeField] private AudioSource winterSound;

    public PlayerMovement playerMovement;
    public GameObject stormGO;
    public List<SeasonObject> allObjects;

    public float stormDuration;
    public float rainDuration;
    public float force;

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
        switch(season)
        {
            case Seasons.SPRING:
                postProcess.profile = springProfile;
                springSound.Play();
                summerSound.Stop();
                autumnSound.Stop();
                winterSound.Stop();
                break;
            case Seasons.SUMMER:
                postProcess.profile = summerProfile;
                springSound.Stop();
                summerSound.Play();
                autumnSound.Stop();
                winterSound.Stop();
                break;
            case Seasons.WINTER:
                postProcess.profile = winterProfile;
                springSound.Stop();
                summerSound.Stop();
                autumnSound.Stop();
                winterSound.Play();
                break;
            case Seasons.AUTUMN:
                postProcess.profile = automnProfile;
                springSound.Stop();
                summerSound.Stop();
                autumnSound.Play();
                winterSound.Stop();
                break;
        }

        foreach (var obj in allObjects)
        {
            obj.SeasonChanged(currentSeason);

            
        }
    }

    public void TornadeEvent()
    {
        playerMovement.ActiveStorm(stormDuration, force, stormGO);
        Debug.Log("Tornado");
    }

    public void FloodEvent()
    {
        playerMovement.ActiveRain(rainDuration);

        foreach (var item in allObjects)
        {
            if (item.GetComponent<River>() != null)
            {
                item.GetComponent<River>().FillWater();
            }
        }

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