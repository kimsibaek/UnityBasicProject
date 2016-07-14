using UnityEngine;
using System.Collections;

public class iTweenPathTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		



	}


	public void PlayTween(){
		Hashtable hash = new Hashtable ();

		hash.Add ("path", iTweenPath.GetPath("NAVIPath"));
		hash.Add ("movetopath", true);
		hash.Add ("orienttopath", true);
		hash.Add ("looktime", 1.0f);
		hash.Add ("time", 3.0f);
		hash.Add ("easetype", iTween.EaseType.linear);
		hash.Add ("looptype", iTween.LoopType.loop);

		hash.Add ("onstart", "ItweenStart");
		hash.Add ("onstarttarget", gameObject);

		hash.Add ("onupdate", "ItweenUpdate");
		hash.Add ("onupdatetarget", gameObject);

		hash.Add ("oncomplete", "ItweenComplete");
		hash.Add ("oncompletetarget", gameObject);

		hash.Add ("ignoretimescale", true);

		iTween.MoveTo (gameObject, hash);
	}


}
