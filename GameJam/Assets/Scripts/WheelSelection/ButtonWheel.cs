using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonWheel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    [SerializeField] private TextMeshProUGUI selectedButtonText;

    [SerializeField] private string selectedButton;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Hovered", true);
        selectedButtonText.text = selectedButton;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Hovered", false);
        selectedButtonText.text = "";
    }
}
