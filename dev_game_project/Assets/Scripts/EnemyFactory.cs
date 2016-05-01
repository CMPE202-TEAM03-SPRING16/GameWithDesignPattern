using UnityEngine;
using System;


public class EnemyFactory : MonoBehaviour
{
	public void getEnemyShip(GameObject ship, Vector3 spawnPosition, Quaternion spawnRotation){

		String shipName = ship.name;
		Debug.Log ("Cuurent Ship"+shipName);
		if (shipName == "EnemyShip") {
			new WeaponController ().enemyShip (ship, spawnPosition, spawnRotation);
		} 
		if (shipName == "health") {
			Instantiate (ship, spawnPosition, spawnRotation);
		}
		if (shipName == "EnemyShip1") {
			new WeaponController().enemyShip (ship, spawnPosition, spawnRotation);
		} 
		if (shipName == "Power") {
			new PowerController().enemyShip (ship, spawnPosition, spawnRotation);
		}

	}
}


