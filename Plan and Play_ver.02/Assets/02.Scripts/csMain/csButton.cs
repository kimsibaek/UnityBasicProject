using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class csButton : MonoBehaviour {
	
	// Use this for initialization
	public GameObject BtnState;
	public GameObject StageOption;

	public GameObject character;

	public GameObject SwitchTile;

	public GameObject door;

	public GameObject Cam;

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
		//Application.LoadLevel("Main");
		csCharacterMove.f_staytime = 0;
		csCharacterMove.anim.SetBool ("StateWalk", false);
		csCharacterMove.b_PlayTime = false;
		csCharacterMove.PlayTime = 0;
		csCharacterMove.StartPlay = true;
		csCharacterMove.GameOver = false;
		csCharacterMove.b_StartMove = false;
		csCharacterMove.SpeedGame = false;
		csCharacterMove.CharacterNoSound = false;
		GameObject obj1 = GameObject.Find ("PlayTimeNumber");
		Text txtStatus1 = obj1.GetComponent<Text> ();
		txtStatus1.text = "Play time 00:00";
		Time.timeScale = 1;
		GameObject Startobj = GameObject.Find ("StartText");
		Text StarttxtStatus = Startobj.GetComponent<Text> ();
		StarttxtStatus.text = "재생";

		character.transform.position = new Vector3 (16, 0.15f, 0);
		character.transform.rotation = Quaternion.Euler (0, 0, 0);

		SwitchTile.GetComponent<csTileState> ().SwitchButton = true;
		SwitchTile.GetComponent<csTileState> ().SwitchButtonDelay = false;
		door.GetComponent<Animation> ().Play ("close");

		Cam.transform.position = new Vector3 (0.7f, 3.3f, 5.6f);
		Cam.transform.rotation = Quaternion.Euler (45.0f, 40.0f, 0.0f);
	}

	public void btnOption(){
		StageOption.SetActive (true);
	}

	public void btnLobby(){
		Application.LoadLevel("Scene_Lobby");
	}

	public void btnBack(){
		StageOption.SetActive (false);
	}
}
