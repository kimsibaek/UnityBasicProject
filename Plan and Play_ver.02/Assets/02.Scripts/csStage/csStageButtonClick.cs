using UnityEngine;
using System.Collections;

public class csStageButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressBack(){
		Application.LoadLevel("Chapter");
	}

	public void PressStage1(){
		Application.LoadLevel("Main");
	}
}
