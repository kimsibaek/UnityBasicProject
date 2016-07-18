using UnityEngine;
using System.Collections;

public class csSwitchButton : MonoBehaviour {
	
	public GameObject character1;

	public GameObject door;

	public GameObject Cam1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log ("OnCollisionEnter");
		if(GetComponent<csTileState>().SwitchButton){
			StartCoroutine ("coAnim");
			GetComponent<csTileState>().SwitchButton = false;
		}

	}

	IEnumerator coAnim(){
		Cam1.GetComponent<Camera> ().depth = 1;
		yield return new WaitForSeconds (0.55f/csCharacterMove.anim.speed);
		csCharacterMove.anim.SetBool ("StateWalk", false);
		csCharacterMove.anim.SetBool ("Switch", true);
		csCharacterMove.f_staytime = 1;
		door.GetComponent<Animation> ().Play ("open");
		GetComponent<csTileState> ().SwitchButtonDelay = true;
		StartCoroutine ("coCameraPosition");
	}
	IEnumerator coCameraPosition(){
		yield return new WaitForSeconds (1.0f);
		Cam1.transform.position = new Vector3 (11.5f, 1.8f, 18.0f);
		Cam1.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		StartCoroutine ("coCameraChange");
	}
	IEnumerator coCameraChange(){
		yield return new WaitForSeconds (2.0f);
		Cam1.GetComponent<Camera> ().depth = -2;
		csCharacterMove.f_staytime = 0;
		csCharacterMove.anim.SetBool ("Switch", false);
		csCharacterMove.anim.SetBool ("StateWalk", true);
		character1.transform.position += Vector3.up * 0.1f;
		StartCoroutine ("coCameraChange2");
	}
	IEnumerator coCameraChange2(){
		yield return 0;
		character1.transform.position += Vector3.up * -0.1f;
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("OnTriggerEnter");

	}

}
