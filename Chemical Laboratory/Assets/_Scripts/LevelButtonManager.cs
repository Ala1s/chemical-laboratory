using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour {

	public void OpenLevelButton(string name)
    {
        SceneManager.LoadScene(name);
    }
}
