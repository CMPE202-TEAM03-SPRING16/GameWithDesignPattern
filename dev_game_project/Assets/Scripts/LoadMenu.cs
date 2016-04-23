using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LoadMenu: MonoBehaviour {
	Receiver receiver ;
	Command quit;
	Command load;
	ConcreteInvoker invoker;
	public bool isQuit;

	public void Awake(){
		receiver = gameObject.AddComponent<LoadOnClick>();
		quit = new QuitCommand(receiver);
		load = new LoadCommand(receiver);
		invoker= new ConcreteInvoker(load,quit);
	}

	void Update()
	{
		//quit game if escape key is pressed
		if (Input.GetKey(KeyCode.Escape)) 
		{ 
//			/Application.LoadLevel(0);
			SceneManager.LoadScene (0);

		}
	}

	public void OnClick(){
		Debug.Log("in gmeload" + isQuit);
		isQuit =true;
		invoker.gameLoad();
	}
}



