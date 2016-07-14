using UnityEngine;
using System.Collections;

public class csRaycast : MonoBehaviour {
	//private float speed = 5.0f;
	// Use this for initialization
	//public Material Mat;
	public GameObject Cam1;
	public GameObject Cam2;

	Renderer objRenderer;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//float amtMove = speed * Time.deltaTime;
		//float hor = Input.GetAxis ("Horizontal");
		//transform.Translate (Vector3.right * hor * amtMove);

		Debug.DrawRay (transform.position, transform.up * -2, Color.red);

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.up * -1, out hit, 2)) {

			Cam2.GetComponent<Camera> ().depth = 1;

			Debug.Log("CameraPath");

			Hashtable hash = new Hashtable ();

			hash.Add ("path", iTweenPath.GetPath("CameraPath"));
			hash.Add ("movetopath", true);
			hash.Add ("orienttopath", true);
			hash.Add ("looktime", 1.0f);
			hash.Add ("time", 3.0f);
			hash.Add ("easetype", iTween.EaseType.linear);
			hash.Add ("looptype", iTween.LoopType.none);

			hash.Add ("onstart", "ItweenStart");
			hash.Add ("onstarttarget", Cam2);

			hash.Add ("onupdate", "ItweenUpdate");
			hash.Add ("onupdatetarget", Cam2);

			hash.Add ("oncomplete", "ItweenComplete");
			hash.Add ("oncompletetarget", Cam2);

			hash.Add ("ignoretimescale", true);

			iTween.MoveTo (Cam2, hash);

			//hit.collider.gameObject
			StartCoroutine ("CharacterIdle");
		}
	}

	IEnumerator CharacterIdle(){
		Debug.Log ("CharacterIdle");

		yield return new WaitForSeconds (1.0f/csCharacterMove.anim.speed);
		StartCoroutine ("timeScaleStop");
	}

	IEnumerator timeScaleStop(){
		Debug.Log ("timeScaleStop");
		//Time.timeScale = 0;
		yield return new WaitForSeconds (4.0f);


		Cam2.GetComponent<Camera> ().depth = -2;
	}
}