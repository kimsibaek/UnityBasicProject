using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class csButton : MonoBehaviour {
	
	// Use this for initialization
	public GameObject BtnState;
	public GameObject StageOption;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void btnMenu(){
		csMousePoint.touchTile = false;
		BtnState.SetActive (true);
	}

	public void btnReStart(){
		Application.LoadLevel("Main");
	}

	public void btnOption(){
		StageOption.SetActive (true);
	}

	public void btnLobby(){
		Application.LoadLevel("Lobby");
	}

	public void btnBack(){
		StageOption.SetActive (false);
	}
}
