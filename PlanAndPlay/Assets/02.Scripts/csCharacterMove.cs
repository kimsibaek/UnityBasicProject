using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csCharacterMove : MonoBehaviour {

	Animator anim;
	public static bool b_PlayTime;
	private float PlayTime;

	Text txtStatus1;

	private bool StartPlay;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		b_PlayTime = false;
		PlayTime = 0;
		StartPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(b_PlayTime){
			PlayTime += Time.deltaTime;
			PlayTimeUpdate ();
		}

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

		GameObject obj1 = GameObject.Find ("PlayTimeNumber");
		txtStatus1 = obj1.GetComponent<Text> ();
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
				StartCoroutine ("coAnimWalk");
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
			
			}

		} else {
			//불가능
			Debug.Log ("game over");
			b_PlayTime = false;
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("game over");
		b_PlayTime = false;
	}

	public void StartAnim(){
		if (StartPlay) {
			StartPlay = false;
			gameObject.transform.position -= Vector3.up * 0.1f; 

		} else {
			
		}

		if (b_PlayTime) {
			b_PlayTime = false;
			anim.SetBool ("StateWalk", false);
			Debug.Log ("일시정지");
		} else {
			b_PlayTime = true;
			anim.SetBool ("StateWalk", true);
			Debug.Log ("재생");
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


}
