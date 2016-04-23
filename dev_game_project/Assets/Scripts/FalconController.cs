using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class FalconController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	private float nextFire;
	public int startingHealth;
	private int currentHealth = 100;




	void Update ()
	{
		if(Input.GetKey(KeyCode.Space) &&  Time.time>nextFire)
		{
			nextFire = Time.time + fireRate;
			foreach (var shotSpawn in shotSpawns) {
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}

		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	//	public int TakeDamage (int amount)
	//	{
	//		// Set the damaged flag so the screen will flash
	//		currentHealth -= amount;
	//		Debug.Log ("currentHealth " + currentHealth);
	//		// Set the health bar's value to the current health.
	//
	//		return currentHealth;
	//	}
}
