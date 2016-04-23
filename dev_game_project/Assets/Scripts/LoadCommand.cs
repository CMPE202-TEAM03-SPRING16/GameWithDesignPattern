using UnityEngine;
using System.Collections;

public class LoadCommand : Command{

	private Receiver theReceiver;

	public LoadCommand (Receiver receiver){
		theReceiver = receiver;
	}

	void Command.execute(){
		Debug.Log ("in con Load scene");
		theReceiver.LoadScene();
	}
}
