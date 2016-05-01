using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public GUIText scoreText;
	private int score;
	public GUIText healthText;
	private int currentHealth; 
	public ScoreObserver scoreTracker;
	public GUIText gameOver;
	private EnemyFactory enemyFactory;

	void Start () {
		currentHealth = 100;
		UpdateScore ();
	
		StartCoroutine (SpawnWaves ());
		healthText.text = "Health: " + "100";
	}

	IEnumerator SpawnWaves ()
	{
			enemyFactory = new EnemyFactory ();
			yield return new WaitForSeconds (startWait);
			while (true) {
			foreach (var hazard in hazards) {
				for (int i = 0; i < hazardCount; i++) {
					Quaternion spawnRotation = Quaternion.identity;
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					enemyFactory.getEnemyShip (hazard, spawnPosition, spawnRotation);
					//Instantiate (hazard, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		
		Debug.Log ("scoreTracker"+scoreTracker);
		//scoreTracker.updatePoints (newScoreValue);
		if (score < 100) {
			Debug.Log ("Update ");
			score += newScoreValue;
		}
		UpdateScore ();
	}

	void UpdateScore ()
	{
		
		scoreText.text = "Score: " + score;
	}

	public void UpdateHealth (int health)
	{

		healthText.text = "Health: " + health;
	}

	public int ReduceHealth (int amount)
	{
		// Set the damaged flag so the screen will flash
		if (currentHealth > 0) {
			currentHealth -= amount;
			Debug.Log ("currentHealth " + currentHealth);
			// Set the health bar's value to the current health.
			UpdateHealth (currentHealth);
			return currentHealth;
		} else {
			
			gameIsOver ();
			return currentHealth;
		}
	}

	public void AddHealth (int amount)
	{
		// Set the damaged flag so the screen will flash

		currentHealth += amount;
		Debug.Log ("Update " + currentHealth);
		// Set the health bar's value to the current health.
		UpdateHealth(currentHealth);

	
	public void gameIsOver ()
	{
		gameOver.text = "Game Over";
	}
}


