using UnityEngine;

public class Deactivator : MonoBehaviour {

    public GameObject IncPopUp;
    public GameObject InfoPopUp;
    public void DeactivateInc()
    {
        IncPopUp.SetActive(false);
    }
    public void DeactivateInfo()
    {
        InfoPopUp.SetActive(false);
    }
}
