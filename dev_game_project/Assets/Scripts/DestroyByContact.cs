using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

	public GameObject explosion, playerExplosion;
	public int scoreValue;
	private Game_Controller gameController;
	//private FalconController damage;
	private int health;

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
		
		Debug.Log ("---->>>"+other.gameObject);
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		if (other.tag == "Health") {

			Debug.Log ("Health ++");
			gameController.AddHealth (20);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.tag == "Player") {
			Debug.Log ("Player Hit");
			//health = damage.TakeDamage (20);
			Debug.Log ("Health " + health);

			health = gameController.ReduceHealth (20);

			Debug.Log (health == 0);
			if (health == 0) {
				Debug.Log ("Boom");
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
			} else {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				return;
			}

		}
		if (explosion != null) {
			
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}


	}
}
