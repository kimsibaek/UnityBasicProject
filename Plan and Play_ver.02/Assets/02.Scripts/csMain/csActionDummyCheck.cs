using UnityEngine;
using System.Collections;

public class csActionDummyCheck : MonoBehaviour {

	GameObject Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("EnemyBody")){
			Debug.Log ("OnTriggerEnter");
			Enemy = other.gameObject;
			Enemy.transform.LookAt (transform);
			StartCoroutine ("ReStartWalk");
		}
	}

	IEnumerator ReStartWalk(){
		Enemy.GetComponent<iTweenPathTest> ().check = false;
		yield return new WaitForSeconds (4.0f/csCharacterMove.anim.speed);
		Enemy.GetComponent<iTweenPathTest> ().check = true;
	}
}
