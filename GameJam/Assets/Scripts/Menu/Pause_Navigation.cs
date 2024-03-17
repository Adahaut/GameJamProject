using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Navigation : MonoBehaviour
{
    [Header("Background & Go")] 
    [SerializeField] Image background;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject prefabMenuPause;
    [SerializeField] GameObject settingsPauseMenu;

    [Header("Buttons")]
    [SerializeField] GameObject resumeBtn;
    [SerializeField] GameObject backPauseSettings;
    [SerializeField] GameObject backToMenu;


    [Header("Player Reference")]
    [SerializeField] PlayerInput playerInput;


    [Header("Animators")]
    [SerializeField] Animator backgroundAnimator;
    [SerializeField] Animator pauseAnimator;
    [SerializeField] Animator settingsAnimator;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SetPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(!pauseMenu.activeInHierarchy && !settingsPauseMenu.activeInHierarchy)
            {
                SetPauseMenu();
            }
            else if(pauseMenu.activeInHierarchy)
            {
                ResumeGame();
            }
            else
            {
                BackToPauseMenu();
            }
        }
    }

    private void SetPauseMenu()
    {
        playerInput.enabled = false;
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(resumeBtn);
        background.enabled = true;
        prefabMenuPause.SetActive(true);
        pauseMenu.SetActive(true);
        pauseAnimator.Play("ButtonsPauseMenu", -1, 0f);
        settingsPauseMenu.SetActive(false);
    }


    public void ResumeGame()
    {
        playerInput.enabled = true;
        Time.timeScale = 1;
        prefabMenuPause.SetActive(false);
        background.enabled = false;
        pauseMenu.SetActive(false);
        settingsPauseMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        EventSystem.current.SetSelectedGameObject(backPauseSettings);
        pauseMenu.SetActive(false);
        settingsPauseMenu.SetActive(true);
        settingsAnimator.Play("OpenSettings", -1, 0f);
    }
        

    public void BackToPauseMenu()
    {
        EventSystem.current.SetSelectedGameObject(resumeBtn);
        settingsPauseMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }


    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
