using UnityEngine;
using System.Collections;

public class csCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		//Debug.Log (collision.gameObject.name);

	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("game over");
		csCharacterMove.b_PlayTime = false;
	}
}
