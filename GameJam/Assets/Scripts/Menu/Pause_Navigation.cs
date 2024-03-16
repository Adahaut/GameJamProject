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

    [Header("Buttons")]
    [SerializeField] GameObject resumeBtn;
    [SerializeField] GameObject settingsPauseMenu;
    [SerializeField] GameObject backPauseSettings;
    [SerializeField] GameObject backToMenu;


    [Header("Player Reference")]
    [SerializeField] GameObject player;
    [SerializeField] PlayerInput playerInput;


    private void Start()
    {
        Time.timeScale = 1;
    }
    public void SetPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerInput.enabled = false;
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(resumeBtn);
            background.enabled = true;
            prefabMenuPause.SetActive(true);
            pauseMenu.SetActive(true);
            settingsPauseMenu.SetActive(false);
        }
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
    }
        

    public void BackToPauseMenu()
    {
        EventSystem.current.SetSelectedGameObject(resumeBtn);
        settingsPauseMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
