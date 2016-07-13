using UnityEngine;
using System.Collections;

public class csSwitchButton : MonoBehaviour {
	public GameObject door1;
	public GameObject door2;

	bool Opendoor;

	float timer;
	// Use this for initialization
	void Start () {
		Opendoor = false;
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Opendoor && timer < 1 ){
			timer += Time.smoothDeltaTime;
			door1.transform.Translate (Vector3.left * Time.smoothDeltaTime);
			door2.transform.Translate (Vector3.right * Time.smoothDeltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		
		transform.Translate (Vector3.up * 0.1f);
		StartCoroutine ("OpenTheDoor");
	}

	IEnumerator OpenTheDoor(){
		yield return new WaitForSeconds(2.0f);
		Opendoor = true;
	}
}
