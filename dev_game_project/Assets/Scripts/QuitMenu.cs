using UnityEngine;
using System;
using System.Collections.Generic;
public class QuitMenu: MonoBehaviour {
	Receiver receiver ;
	Command c;
	Command s;
	ConcreteInvoker i;
	public bool isQuit;

	public void Awake(){
		receiver = gameObject.AddComponent<LoadOnClick>();
		c = new QuitCommand(receiver);
		s = new LoadCommand(receiver);
		i= new ConcreteInvoker(s,c);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{ 
			Application.LoadLevel(0);
		}
	}

	public void OnClick(){
		Debug.Log("on mouse" + isQuit);
		i.gameQuit();
	}
}



