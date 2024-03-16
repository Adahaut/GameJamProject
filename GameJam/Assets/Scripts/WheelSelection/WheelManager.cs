using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    public static WheelManager instance {  get; private set; }
    
    [SerializeField] private GameObject firstWheel;
    [SerializeField] private GameObject seasonsWheel;
    [SerializeField] private GameObject eventsWheel;


    [SerializeField] private List<ButtonWheel> buttonFirstWheel;
    [SerializeField] private List<ButtonWheel> buttonSeasonsWheel;
    [SerializeField] private List<ButtonWheel> buttonEventsWheel;

    private ButtonWheel selectedButton;
    GameObject currentWheel;
    List<ButtonWheel> currentList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        firstWheel.SetActive(false);
    }

    public void OpenWheel(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            firstWheel.SetActive(true);
            currentWheel = firstWheel;
            currentList = buttonFirstWheel;
            GetComponent<PlayerInput>().SwitchCurrentActionMap("SelectionWheel");
        }
    }

    public void StayOpenedWheel(InputAction.CallbackContext ctx)
    {
        currentWheel.SetActive(true);

        if (ctx.canceled)
        {
            DisableWheels(true);
        }
    }

    public void DisableWheels(bool changeInputMap)
    {
        firstWheel.SetActive(false);
        seasonsWheel.SetActive(false);
        eventsWheel.SetActive(false);
        if(currentWheel != null)
            currentWheel.SetActive(false);
        if (changeInputMap) 
            GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerMovement");
    }

    public void ShiftOpenWheel(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            firstWheel.SetActive(true);
        }
        if(ctx.canceled)
        {
            DisableWheels(true);
        }
    }

    public void MoveLeftJoystick(InputAction.CallbackContext ctx)
    {
        Vector2 joystickPosition = ctx.ReadValue<Vector2>();
        foreach (var wheel in currentList)
        {
            if(joystickPosition.x >= wheel.minJoystickPosition.x && joystickPosition.x <= wheel.maxJoystickPosition.x
                && joystickPosition.y >= wheel.minJoystickPosition.y && joystickPosition.y <= wheel.maxJoystickPosition.y)
            {
                if(!wheel.hovered)
                {
                    selectedButton = wheel;
                    wheel.SetHovered();
                }
                    
            }
            else
            {
                if(wheel.hovered)
                {
                    selectedButton = null;
                    wheel.SetUnHovered();
                }
                    
            }
        }
    }

    public void SelectButton(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && selectedButton != null)
        {
            selectedButton.transform.GetComponent<Button>().onClick.Invoke();
        }
            
    }

    public void OpenSeasonWheel()
    {
        DisableWheels(false);
        seasonsWheel.SetActive(true);
        currentWheel = seasonsWheel;
        currentList = buttonSeasonsWheel;
    }

    public void OpenEventWheel()
    {
        DisableWheels(false);
        eventsWheel.SetActive(true);
        currentWheel = eventsWheel;
        currentList = buttonEventsWheel;

    }
}
