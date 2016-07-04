using UnityEngine;
using System.Collections;

public class csLobbyButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressStart(){
		Application.LoadLevel("Chapter");
	}
}
