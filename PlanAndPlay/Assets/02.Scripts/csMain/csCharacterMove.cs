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

	bool SpeedGame;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		b_PlayTime = false;
		PlayTime = 0;
		StartPlay = true;
		GameOver = false;
		b_StartMove = false;
		SpeedGame = false;
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
					transform.Translate (Vector3.forward * anim.speed * Time.smoothDeltaTime);
				}

			}
		
		}

	}

	IEnumerator coAnimTime(){
		//Debug.Log ("coAnimTime");
		anim.SetBool ("StateWalk", false);
		yield return new WaitForSeconds(0.45f);
		b_StartMove = true;
		//Debug.Log("coAnimTime");
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
			case 8:
				Debug.Log ("오브젝트 이동");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 9:
				Debug.Log ("가속");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 10:
				Debug.Log ("은신");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 11:
				Debug.Log ("스카우터");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 12:
				Debug.Log ("무음기동");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 13:
				Debug.Log ("더미 설치");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 14:
				Debug.Log ("EMP");
				StartCoroutine ("coAnimStayThree");
				//coAnimTurnRight ();
				break;
			case 15:
				Debug.Log ("와이어");
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
		csMousePoint.touchTile = false;
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
		csMousePoint.touchTile = false;
		if(Time.timeScale == 0){
			return;
		}
		if (!SpeedGame) {
			//2배속
			SpeedGame = true;
			anim.speed = 2;

		} else {
			//1배속
			SpeedGame = false;
			anim.speed = 1;

		}

	}

	void coAnimWalk(){
		//anim.SetBool ("StateWalk", true);

	}

	IEnumerator ReStartWalk(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (f_staytime);
		} else {
			yield return new WaitForSeconds (f_staytime/2);
		}	
		anim.SetBool ("StateWalk", true);
		f_staytime = 0;
	}

	IEnumerator coAnimTurnUp(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		transform.rotation = Quaternion.Euler (0, 0, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnDown(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		transform.rotation = Quaternion.Euler (0, 180.0f, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnLeft(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		transform.rotation = Quaternion.Euler (0, 270.0f, 0);
		//anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnRight(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		transform.rotation = Quaternion.Euler (0, 90.0f, 0);	
		//anim.SetBool ("StateWalk", true);
	}
	IEnumerator coAnimStayOne(){
		
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		f_staytime = 1;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");

	}
	IEnumerator coAnimStayTwo(){
		
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		f_staytime = 2;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}
	IEnumerator coAnimStayThree(){
		
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		f_staytime = 3;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}

	IEnumerator ActionObjMove(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
		f_staytime = 1;
		anim.SetBool ("StateWalk", false);
		StartCoroutine ("ReStartWalk");
	}
	IEnumerator ActionSpeed(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
	IEnumerator ActionFad(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
	IEnumerator ActionScout(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
	IEnumerator ActionSound(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
	IEnumerator ActiondummyInstall(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
	IEnumerator ActionEMP(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
	IEnumerator ActionWire(){
		if (!SpeedGame) {
			yield return new WaitForSeconds (0.45f);
		} else {
			yield return new WaitForSeconds (0.225f);
		}
	}
}
