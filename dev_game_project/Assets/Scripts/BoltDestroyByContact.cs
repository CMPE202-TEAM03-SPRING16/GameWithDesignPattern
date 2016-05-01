using UnityEngine;
using System.Collections;

	public class BoltDestroyByContact : MonoBehaviour
	{
	public GameObject explosion, playerExplosion;
	public int scoreValue;
	private Game_Controller gameController;
		void Start ()
		{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			if (gameControllerObject != null) {
				gameController = gameControllerObject.GetComponent <Game_Controller> ();
			//damage = new FalconController ();
			}
			if (gameController == null) {
				Debug.Log ("Cannot find 'GameController' script");
			}
		}


	void OnTriggerEnter (Collider other)
	{


		if (other.tag == "Boundary" || other.tag == "Health") {
			return;
		}

		if (other.tag == "Enemy") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			return;
		}
		if (other.tag == "Player") {
			
			return;
		}
		if (other.tag == "Power") {
			return;
		}
		if (explosion != null) {
			Debug.Log ("Explosions ");
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}


	}
	}


