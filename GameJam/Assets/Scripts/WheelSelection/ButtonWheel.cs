using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonWheel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    [SerializeField] private TextMeshProUGUI selectedButtonText;

    [SerializeField] private string selectedButton;
    [SerializeField] private Seasons buttonSeason;

    public Vector2 minJoystickPosition;
    public Vector2 maxJoystickPosition;

    public bool hovered;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetHovered();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetUnHovered();
    }

    public void SetHovered()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        hovered = true;
        animator.SetBool("Hovered", true);
        selectedButtonText.text = selectedButton;
        
    }

    public void SetUnHovered()
    {
        hovered = false;
        animator.SetBool("Hovered", false);
        selectedButtonText.text = "";
    }

    public void SetSeason()
    {
        SeasonManager.instance.ChangeSeason(buttonSeason);
        //WheelManager.instance.DisableWheels();
    }

}
