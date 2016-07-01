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
				coAnimWalk ();
				StartCoroutine ("coAnimWalk");
				break;
			case 1:
				Debug.Log ("coAnimTurnLeft");
				coAnimTurnLeft ();
				//StartCoroutine ("coAnimTurnLeft");
				break;
			case 2:
				Debug.Log ("coAnimTurnRight");
				coAnimTurnRight ();
				//StartCoroutine ("coAnimTurnRight");
				break;
			case 3:
				Debug.Log ("coAnimHalfTurnLeft");
				coAnimHalfTurnLeft ();
				//StartCoroutine ("coAnimHalfTurnLeft");
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
		//GetComponent<Animation>().Play("HumanoidWalk");
		anim.SetBool ("HumanState", true);
		//yield return new WaitForSeconds (0.5f);
	}

	void coAnimTurnLeft(){
		
		//GetComponent<Animation>().Play("StandQuarterTurnLeft");

		GetComponent<Animation> ().Play ("HumanoidWalk");
		//anim.SetInteger ("TurnState", 1);
		//yield return new WaitForSeconds (0.5f);
		//anim.SetInteger ("TurnState", 0);
	}

	void coAnimTurnRight(){
		//GetComponent<Animation>().Play("StandQuarterTurnRight");

		GetComponent<Animation> ().Play ("HumanoidWalk");
		//anim.SetInteger ("TurnState", 2);
		//yield return new WaitForSeconds (0.5f);
		//anim.SetInteger ("TurnState", 0);
	}

	void coAnimHalfTurnLeft(){
		//GetComponent<Animation>().Play("StandHalfTurnLeft");

		GetComponent<Animation> ().Play ("HumanoidWalk");
		//anim.SetInteger ("TurnState", 3);
		//yield return new WaitForSeconds (0.5f);
		//anim.SetInteger ("TurnState", 0);
	}
}
