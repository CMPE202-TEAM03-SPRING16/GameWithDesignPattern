using System;
using UnityEngine;

public class ScoreObserver :MonoBehaviour, IScoreObserver{
	Game_Controller player = new Game_Controller();
	private static ScoreObserver observer;
	private int playerPoints;

	public ScoreObserver(){
		playerPoints = 0;
	}

	public void updatePoints(int points){
		playerPoints = playerPoints + points;
	}

	public int getPlayerPoints(){
		return playerPoints;
	}

	public static ScoreObserver getInstance(){
		if (observer == null) {
			observer = new ScoreObserver ();
		}
		return observer;
	}
}