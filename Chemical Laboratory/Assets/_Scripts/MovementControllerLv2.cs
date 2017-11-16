using UnityEngine;

public class MovementControllerLv2 : MonoBehaviour {

    public GameObject[] reagents;
    public GameObject[] products;
    private void FixedUpdate()
    {
        for (int i = 0; i < reagents.Length; i++)
        {
            for (int j = 0; j < reagents[i].transform.childCount; j++)
            {
                if (reagents[i].transform.GetChild(j).GetComponent<SelectionController>().isSelected)
                {
                    for (int k = 0; k < products.Length; k++)
                    {
                        for (int m = 0; m < products[k].transform.childCount; m++)
                        {
                            if (products[k].transform.GetChild(m).GetComponent<SelectionController>().isSelected)
                            {
                                reagents[i].transform.GetChild(j).position = products[k].transform.GetChild(m).position;
                                reagents[i].transform.GetChild(j).GetComponent<SelectionController>().isSelected = false;
                                products[k].transform.GetChild(m).GetComponent<SelectionController>().isSelected = false;
                                reagents[i].transform.GetChild(j).SetParent(products[k].transform.GetChild(m).transform);

                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < products.Length; i++)
        {
            for (int j = 0; j < products[i].transform.childCount; j++)
            {
                for (int q = 0; q < products[i].transform.GetChild(j).transform.childCount; q++)
                {
                    if (products[i].transform.GetChild(j).transform.GetChild(q).GetComponent<SelectionController>().isSelected)
                    {
                        for (int k = 0; k < products.Length; k++)
                        {
                            for (int m = 0; m < products[k].transform.childCount; m++)
                            {
                                if (products[k].transform.GetChild(m).GetComponent<SelectionController>().isSelected)
                                {
                                    products[i].transform.GetChild(j).transform.GetChild(q).position = products[k].transform.GetChild(m).position;
                                    products[i].transform.GetChild(j).transform.GetChild(q).GetComponent<SelectionController>().isSelected = false;
                                    products[k].transform.GetChild(m).GetComponent<SelectionController>().isSelected = false;
                                    products[i].transform.GetChild(j).transform.GetChild(q).SetParent(products[k].transform.GetChild(m).transform);

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public bool IsCorrect()
    {
        int count = 0;
        for (int i = 0; i < products.Length; i++)
        {
            int countp = 0;
            int counto = 0;
            for (int j = 0; j < products[i].transform.childCount; j++)
            {
                for (int k = 0; k < products[i].transform.GetChild(j).transform.childCount; k++)
                {
                    if (products[i].transform.GetChild(j).transform.GetChild(k).tag == "Phosphorus") countp++;
                }
                for (int l = 0; l < products[i].transform.GetChild(j).transform.childCount; l++)
                {
                    if (products[i].transform.GetChild(j).transform.GetChild(l).tag == "Oxygen") counto++;
                }
            }
            if (countp == 2 && counto == 5) count++;
        }
        if (count==2) return true;
        else return false;
    }
}
