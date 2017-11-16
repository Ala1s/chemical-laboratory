using UnityEngine;

public class TextManager : MonoBehaviour {
	public GameObject[] text;
	public void DestroyText(){
		for (int i = 0; i < text.Length; i++) {
			text [i].SetActive (false);
		}
	}
	public void AppearText(){
		for (int i = 0; i < text.Length; i++) {
			text [i].SetActive (true);
		}
	}
}
