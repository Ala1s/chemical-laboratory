using UnityEngine;

public class TipBM : MonoBehaviour {
    public GameObject tipPanel;
    public void Activate()
    {
        tipPanel.SetActive(true);
    }
    public void Deactivate()
    {
        tipPanel.SetActive(false);
    }
}
