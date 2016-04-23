using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadOnClick : MonoBehaviour,Receiver {

	public GameObject loadingImage;

	void OnStart(){
	}

	public void LoadScene(){
		Debug.Log ("Load scene");
		//Application.LoadLevel(1);
		SceneManager.LoadScene (1);

	}

	public void QuitGame(){
		Debug.Log ("in quit game");
		SceneManager.LoadScene (0);
	}
}

