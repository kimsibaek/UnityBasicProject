using UnityEngine;
using System.Collections;

public class csPressStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1)
		{
			PressStart ();
		}
	}

	void PressStart(){
		Application.LoadLevel("Lobby");
	}
}
