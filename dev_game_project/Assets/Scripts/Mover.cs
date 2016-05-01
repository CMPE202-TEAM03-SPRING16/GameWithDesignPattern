using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private SpeedManager manager;
	Time curTime;
	SpeedManager speedManager;
	void Start ()
	{
		speedManager = new SpeedManager (this); 
//		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		if (gameObject.tag == "Health" || gameObject.tag == "Power") {
			GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		} else {
			GetComponent<Rigidbody> ().velocity = transform.forward * (speed - (Time.time / 5));
		}

	}

	private void ScoreInc(){
		curTime += 1;
		if (curTime < 25) {
			if (curTime > 5 && curTime <= 10) {
				speedManager.SetNewSpeed ("low");
			} else if (curTime > 10 && curTime <= 20) {
				speedManager.SetNewSpeed ("medium");
			} else if (curTime > 20) {
				speedManager.SetNewSpeed ("high");
			}
		}

	}
}
