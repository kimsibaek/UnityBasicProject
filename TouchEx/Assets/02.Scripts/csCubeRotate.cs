using UnityEngine;
using System.Collections;

public class csCubeRotate : MonoBehaviour {
	float accTime = 0.0f;
	bool bRotate = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (accTime > 1.0) {
			bRotate = false;
		}

		if(bRotate){
			accTime += Time.deltaTime;

			transform.Rotate (100.0f * Time.deltaTime * Vector3.up);
		}
	}

	public void RotateByHit(){
		accTime = 0.0f;
		bRotate = true;
	}
}
