using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform returnParent = null;
    public Transform placeholderParent = null;
    public GameObject placeholder = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        returnParent = transform.parent;
        placeholderParent = returnParent;
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        if (placeholder.transform.parent!=placeholderParent)
        {
            placeholder.transform.SetParent(placeholderParent);
        }
        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                placeholder.transform.SetSiblingIndex(i);
                break;
            }
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(returnParent);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
    }
}
