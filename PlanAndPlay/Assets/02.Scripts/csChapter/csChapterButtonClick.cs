using UnityEngine;
using System.Collections;

public class csChapterButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressBack(){
		Application.LoadLevel("Lobby");
	}

	public void PressChapter1(){
		Application.LoadLevel("Stage");
	}
}
