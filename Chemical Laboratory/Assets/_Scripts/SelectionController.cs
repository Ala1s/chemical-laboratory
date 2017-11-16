using UnityEngine;

public class SelectionController : MonoBehaviour {
    public bool isSelected = false;
    private void OnMouseDown()
    {
        isSelected = !isSelected;
    }
}
