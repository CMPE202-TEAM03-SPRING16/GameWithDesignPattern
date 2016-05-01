using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class FalconController : MonoBehaviour {
	public float speed = 10f;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform[] shotSpawns;
	private float fireRate = 0.25f;
	private float nextFire;
	public int startingHealth;
	private int currentHealth = 100;
	private SpeedManager speedManager;
	private float curTime = 0f;


	void Start(){
		//speedManager = new SpeedManager (this);
		InvokeRepeating ("ScoreInc", 1f, 1f);

	}

	void Update ()
	{
		if(Input.GetKey(KeyCode.Space) &&  Time.time>nextFire)
		{
			Debug.Log ("FR --- "+this.fireRate);
			nextFire = Time.time + this.fireRate;
			Debug.Log ("Next Fire " + nextFire);
			foreach (var shotSpawn in shotSpawns) {
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
	}

	public void setFireRate(float fireRate)
	{ 
		Debug.Log ("Fire Rate set ");
		this.fireRate = fireRate;
		Debug.Log (fireRate);
	}

	public float getFireRate()
	{
		Debug.Log ("Fire Rate Updated " + this.fireRate);
		return this.fireRate;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
