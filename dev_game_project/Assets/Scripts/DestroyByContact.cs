using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

	public GameObject explosion, playerExplosion,pointLight;
	public int scoreValue;
	private Game_Controller gameController;
	//private FalconController damage;
	private int health;
	private Light light;

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
		pointLight = GameObject.FindGameObjectWithTag ("PowerLight");
		light = pointLight.GetComponent<Light>();
	}


	void OnTriggerEnter (Collider other)
	{
		

		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		if (other.tag == "Health") {


			return;

		}
		if (other.tag == "Player") {
			Debug.Log ("Intensity "+light.intensity);
			if (light.intensity == 1) {
				light.intensity = 0;
				return;
			} else {
				health = gameController.ReduceHealth (20);
				Debug.Log ("<3 <3 <3"+health);
				if (health == 0) {
					Debug.Log ("Boom");
					Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
					Destroy (other.gameObject);
					Destroy (gameObject);

					gameController.gameIsOver ();

				} else {
				
					return;
				}
			}
		}
		if (other.tag == "Power") {
			return;
		}
		if (explosion != null) {
			
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}


	}
}
