using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    public static WheelManager instance {  get; private set; }
    
    [SerializeField] private GameObject firstWheel;
    [SerializeField] private GameObject seasonsWheel;


    [SerializeField] private List<ButtonWheel> buttonFirstWheel;
    [SerializeField] private List<ButtonWheel> buttonSeasonsWheel;

    private ButtonWheel selectedButton;

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
            GetComponent<PlayerInput>().SwitchCurrentActionMap("SelectionWheel");
        }
    }

    public void StayOpenedWheel(InputAction.CallbackContext ctx)
    {
        firstWheel.SetActive(true);

        if (ctx.canceled)
        {
            firstWheel.SetActive(false);
            GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerMovement");
        }
    }

    public void ShiftOpenWheel(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            firstWheel.SetActive(true);
        }
        if(ctx.canceled)
        {
            firstWheel.SetActive(false);
            seasonsWheel.SetActive(false);
        }
    }

    public void MoveLeftJoystick(InputAction.CallbackContext ctx)
    {
        Vector2 joystickPosition = ctx.ReadValue<Vector2>();
        foreach (var wheel in buttonFirstWheel)
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
        if(ctx.performed)
            selectedButton.transform.GetComponent<Button>().onClick.Invoke();
    }

    public void OpenSeasonWheel()
    {
        firstWheel.SetActive(false);
        seasonsWheel.SetActive(true);
    }
}
