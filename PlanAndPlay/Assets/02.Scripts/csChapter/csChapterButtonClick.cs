using UnityEngine;
using System.Collections;

public class csChapterButtonClick : MonoBehaviour {

	Rect rScrollRect;  // 화면상의 스크롤 뷰의 위치
	Rect rScrollArea; // 총 스크롤 되는 공간
	Vector2 vScrollPos; // 스크롤 바의 위치
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
