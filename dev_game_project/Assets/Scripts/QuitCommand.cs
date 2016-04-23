using UnityEngine;
using System.Collections;

public class QuitCommand : Command{

	private Receiver theReceiver;

	public QuitCommand (Receiver receiver){
		theReceiver = receiver;
	}

	void Command.execute(){
		Debug.Log ("in con Load scene");
		theReceiver.QuitGame();
	}
}

