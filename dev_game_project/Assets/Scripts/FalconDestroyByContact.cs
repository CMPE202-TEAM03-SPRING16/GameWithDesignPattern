using UnityEngine;
using System.Collections;

public class FalconDestroyByContact : MonoBehaviour, IHealthObserver {

	// Use this for initialization
	public GameObject explosion, playerExplosion;
	public int scoreValue;
	private Game_Controller gameController;
	private int health;
	public FalconController ship;
	public float duration = 1.0F;
	public Light light;
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
		ship = new FalconController ();
	}

	void OnTriggerEnter (Collider other)
	{


		if (other.tag == "Boundary" ) {
			
			return;
		}
		if (other.tag == "Health") {
			Destroy (other.gameObject);
			updateHealth ();
			return;
		}
		if (other.tag == "Power") {
			Destroy (other.gameObject);
			light.intensity = 1.0F;
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			Debug.Log ("Enemies------>>>>>> "+enemies);

			foreach (var enemy in enemies) {
				Instantiate (explosion, enemy.transform.position, enemy.transform.rotation);
				Destroy (enemy);

			}

			return;
		}
		if (other.tag == "Enemy") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			//Destroy (gameObject);
			return;
		}

		if (other.tag == "EnemyBolt") {
			Debug.Log ("FalconDestroyByContact");
		}

		if (explosion != null) {

			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	public void updateHealth()
	{
		gameController.AddHealth (20);
	}

}
