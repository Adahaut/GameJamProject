using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Navigation : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject creditsMenu;
        
    public void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(0); //Mettre l'index ou le nom de la scène de jeu
    }

    public void SettingsButton()
    {
        Debug.Log("bite;");
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void BackButtonForMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
