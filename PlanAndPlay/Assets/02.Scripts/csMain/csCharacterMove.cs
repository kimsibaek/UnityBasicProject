using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csCharacterMove : MonoBehaviour {

	Animator anim;
	public static bool b_PlayTime;
	public static float PlayTime;

	bool b_StartMove;

	private bool StartPlay;

	public static bool GameOver;

	float f_staytime;

	GameObject obj1;
	Text txtStatus1;

	GameObject Startobj;
	Text StarttxtStatus;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		b_PlayTime = false;
		PlayTime = 0;
		StartPlay = true;
		GameOver = false;
		b_StartMove = false;
		obj1 = GameObject.Find ("PlayTimeNumber");
		txtStatus1 = obj1.GetComponent<Text> ();

		Startobj = GameObject.Find ("StartText");
		StarttxtStatus = Startobj.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(b_PlayTime){
			PlayTime += Time.deltaTime;
			PlayTimeUpdate ();
			if(b_StartMove){
				//Debug.Log ("Move");
				if(f_staytime == 0){
					transform.Translate (Vector3.forward * Time.smoothDeltaTime);
				}

			}
		
		}

	}

	IEnumerator coAnimTime(){
		csMousePoint.touchTile = false;
		Debug.Log ("coAnimTime");
		anim.SetBool ("StateWalk", false);
		yield return new WaitForSeconds(0.45f);
		b_StartMove = true;
		Debug.Log("coAnimTime");
		anim.SetBool ("StateWalk", true);
	}

	void PlayTimeUpdate(){
		string hour;
		string second;

		int i = (int)(PlayTime / 60);
		if (i < 10) {
			hour = "0" + i;
		} else {
			hour = "" + i;
		}

		int j = (int)(PlayTime % 60);
		if (j < 10) {
			second = "0" + j;
		} else {
			second = "" + j;
		}


		txtStatus1.text = "Play time " + hour + ":" + second;
	}

	void OnCollisionEnter(Collision collision){
		//Debug.Log (collision.gameObject.name);
		csTileState TS = collision.gameObject.GetComponent<csTileState> ();
		if (TS.state) {
			//가능
			switch(TS.stateNum){
			case 0:
				Debug.Log ("coAnimWalk");
				//StartCoroutine ("coAnimWalk");
				break;
			case 1:
				Debug.Log ("coAnimTurnUp");
				StartCoroutine ("coAnimTurnUp");
				//coAnimTurnUp ();
				break;
			case 2:
				Debug.Log ("coAnimTurnDown");
				StartCoroutine ("coAnimTurnDown");
				//coAnimTurnDown();
				break;
			case 3:
				Debug.Log ("coAnimTurnLeft");
				StartCoroutine ("coAnimTurnLeft");
				//coAnimTurnLeft ();
				break;
			case 4:
				Debug.Log ("coAnimTurnRight");
				StartCoroutine ("coAnimTurnRight");
				//coAnimTurnRight ();
				break;
			case 5:
				Debug.Log ("coAnimStayOne");
				StartCoroutine ("coAnimStayOne");
				//coAnimTurnRight ();
				break;
			case 6:
				Debug.Log ("coAnimStayTwo");
				StartCoroutine ("coAnimStayTwo");
				//coAnimTurnRight ();
				break;
			case 7:
				Debug.Log ("coAnimStayThree");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			}

		} else {
			//불가능
			Debug.Log ("game over");
			GameOver = true;
			anim.SetBool ("StateWalk", false);
			f_staytime = 1;
			//Application.LoadLevel("Result");

		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Sucess")) {
			Debug.Log ("game Sucess");
			GameOver = false;
		} else {
			Debug.Log ("game over");
			GameOver = true;
		}
		Application.LoadLevel("Result");
	}

	public void StartAnim(){
		if (StartPlay) {
			StartPlay = false;
			gameObject.transform.position -= Vector3.up * 0.1f; 
			StartCoroutine ("coAnimTime");
			b_PlayTime = true;



		} else {
			if (b_PlayTime) {
				b_PlayTime = false;
				anim.SetBool ("StateWalk", false);
				Debug.Log ("일시정지");
				StarttxtStatus.text = "일시정지";
				Time.timeScale = 0;

			} else {
				b_PlayTime = true;
				anim.SetBool ("StateWalk", true);
				Debug.Log ("재생");

				StarttxtStatus.text = "재생";
				Time.timeScale = 1;
			}
		}


	}

	public void SpeedTime(){
		if(Time.timeScale == 0){
			return;
		}
		if (Time.timeScale == 1) {
			Time.timeScale = 2;
		} else {
			Time.timeScale = 1;
		}

	}

	void coAnimWalk(){
		//anim.SetBool ("StateWalk", true);

	}

	IEnumerator coAnimTurnUp(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 0, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnDown(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 180.0f, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnLeft(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 270.0f, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnRight(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 90.0f, 0);	
		//anim.SetBool ("StateWalk", true);
	}
	IEnumerator coAnimStayOne(){
		
		yield return new WaitForSeconds(0.45f);
		f_staytime = 1;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");

	}
	IEnumerator coAnimStayTwo(){
		
		yield return new WaitForSeconds(0.45f);
		f_staytime = 2;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}
	IEnumerator coAnimStayThree(){
		
		yield return new WaitForSeconds(0.45f);	
		f_staytime = 3;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}


	IEnumerator ReStartWalk(){
		yield return new WaitForSeconds(f_staytime);	
		anim.SetBool ("StateWalk", true);
		f_staytime = 0;
	}
}
