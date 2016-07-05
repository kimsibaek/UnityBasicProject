using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csResultButtonClick : MonoBehaviour {
	Text txtStatus1;
	Text txtStatus2;
	float P_Time;

	// Use this for initialization
	void Start () {
		GameObject obj1 = GameObject.Find ("Result");
		txtStatus1 = obj1.GetComponent<Text> ();
		GameObject obj2 = GameObject.Find ("PlayTime");
		txtStatus2 = obj2.GetComponent<Text> ();
		P_Time = csCharacterMove.PlayTime;
		string hour;
		string second;

		int i = (int)(P_Time / 60);
		if (i < 10) {
			hour = "0" + i;
		} else {
			hour = "" + i;
		}

		int j = (int)(P_Time % 60);
		if (j < 10) {
			second = "0" + j;
		} else {
			second = "" + j;
		}
		txtStatus2.text = "Play time " + hour + ":" + second;

		if (csCharacterMove.GameOver) {
			//실패
			txtStatus1.text = "실패하셨습니다.";
		} else {
			//성공
			txtStatus1.text = "성공하셨습니다.";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressStage(){
		Application.LoadLevel("Stage");
	}

	public void PressLobby(){
		Application.LoadLevel("Lobby");
	}
}
