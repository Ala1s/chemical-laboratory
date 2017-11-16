using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneLv2 : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string[] correctEquation;
    public GameObject WinPopUp;
    public GameObject IncPopUp;
	public MovementControllerLv2 mc;
    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.returnParent = transform;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = transform;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == transform)
        {
            d.placeholderParent = d.returnParent;
        }
    }
    public bool IsEquationCorrect(string[] equation)
    {
        bool[] isPresent = new bool[equation.Length];
        for (int i = 0; i < isPresent.Length; i++)
        {
            isPresent[i] = false;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == equation[i]) isPresent[i] = true;
        }
        for (int i = 0; i < isPresent.Length; i++)
        {
            if (!isPresent[i]) return false;
        }
        Debug.Log("eq is correct");
        return true;
    }
    public void Check()
    {
        if (IsEquationCorrect(correctEquation) && (mc.IsCorrect()))
        {
            WinPopUp.SetActive(true);
        }
        else IncPopUp.SetActive(true);

    }
}