using UnityEngine;
using System.Collections;

public class csCharacterMove : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log (collision.gameObject.name);
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
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("OnTriggerEnter");
	}

	public void StartAnim(){
		gameObject.transform.position -= Vector3.up * 0.1f; 
	}

	void coAnimWalk(){
		anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnUp(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 0, 0);
		anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnDown(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 180.0f, 0);
		anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnLeft(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 270.0f, 0);
		anim.SetBool ("StateWalk", true);
	}

	IEnumerator coAnimTurnRight(){
		yield return new WaitForSeconds(0.45f);
		transform.rotation = Quaternion.Euler (0, 90.0f, 0);
		anim.SetBool ("StateWalk", true);
	}


}
