using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public GameObject panel;

    public void LevelMenuButton()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void InfoButton()
    {
        panel.SetActive(true);
    }
    public void CloseButton()
    {
        panel.SetActive(false);
    }
}
