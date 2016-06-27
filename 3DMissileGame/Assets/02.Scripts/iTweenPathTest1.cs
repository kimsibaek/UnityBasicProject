using UnityEngine;
using System.Collections;

public class iTweenPathTest1 : MonoBehaviour {
	public int HP = 5;

	public float deltaTime = 0.0f;
	public float deleteTime = 30.0f;
	// Use this for initialization
	void Start () {
		Hashtable hash = new Hashtable ();

		hash.Add ("path", iTweenPath.GetPath("MyPath1"));
		hash.Add ("movetopath", true);
		hash.Add ("orienttopath", true);
		hash.Add ("looktime", 1.0f);
		hash.Add ("time", 10.0f);
		hash.Add ("easetype", iTween.EaseType.linear);
		hash.Add ("looptype", iTween.LoopType.loop);

		hash.Add ("ignoretimescale", true);

		iTween.MoveTo (gameObject, hash);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other){
		HP--;
		Debug.Log ("HP : " + HP);
		if(HP < 0){
			Destroy (gameObject);
		}
	}

	void OnBecameVisible() {
		Debug.Log ("enemy1");
	}

	void ItweenStart(){
		Debug.Log ("Tween Start : " + Time.realtimeSinceStartup);
	}

	void ItweenUpdate(){
		Debug.Log ("Tween Update : " + Time.realtimeSinceStartup);
	}

	void ItweenComplete(){
		Debug.Log ("Tween Complete : " + Time.realtimeSinceStartup);
	}
}
