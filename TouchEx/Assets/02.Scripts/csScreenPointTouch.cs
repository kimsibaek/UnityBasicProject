using UnityEngine;
using System.Collections;

public class csScreenPointTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Ended) {
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit)){
					if(hit.transform.tag.Equals("Player")){
						csCubeRotate cubeScript = hit.transform.GetComponent<csCubeRotate> ();
						if(cubeScript != null){
							cubeScript.RotateByHit ();
						}
					}
				}
			}
		}
	}
}
