using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csTouch : MonoBehaviour {
	int size = 1;
	Text txtStatus1;
	Text txtStatus2;

	// Use this for initialization
	void Start () {
		GameObject obj1 = GameObject.Find ("txtStatus1");
		GameObject obj2 = GameObject.Find ("txtStatus2");
		txtStatus1 = obj1.GetComponent<Text> ();
		txtStatus2 = obj2.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		txtStatus1.fontSize = Screen.height * size / 25;
		txtStatus2.fontSize = Screen.height * size / 25;

		int fingerCount = 0;

		foreach(Touch touch in Input.touches){
			if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
				fingerCount++;
			}
			if(touch.phase == TouchPhase.Began){
				if (touch.position.x > Screen.width / 2) {
					txtStatus1.text = "화면의 오른쪽 터치...";
				} else {
					txtStatus1.text = "화면의 왼쪽 터치...";
				}
			}
		}

		if(fingerCount > 0){
			txtStatus2.text = "Touch Count : " + fingerCount;
		}
	}
}
