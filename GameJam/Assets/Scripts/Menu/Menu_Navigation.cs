using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Navigation : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject creditsMenu;

    [SerializeField] GameObject playbtn;
    [SerializeField] GameObject backSettings;
    [SerializeField] GameObject backCredits;

    [Header("Animators")]
    [SerializeField] Animator mainMenuAnimator;
    [SerializeField] Animator settingsAnimator;
    [SerializeField] Animator creditsAnimator;


    public void Start()
    {
        mainMenu.SetActive(true);
        mainMenuAnimator.Play("LaunchGameMenu");
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene("Clement"); //Mettre l'index ou le nom de la scène de jeu
    }

    public void SettingsButton()
    {
        EventSystem.current.SetSelectedGameObject(backSettings);
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        EventSystem.current.SetSelectedGameObject(backCredits);
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void BackButtonForMenu()
    {
        EventSystem.current.SetSelectedGameObject(playbtn);
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
