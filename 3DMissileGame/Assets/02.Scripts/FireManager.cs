using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour {
	public Transform FirePosition;
	public static Transform TargetObject;
	public GameObject fireObject;

	public static bool target = false;

	public static int Enemy1 = 0;
	//public static int Enemy2 = 0;
	//public static int Enemy3 = 0;
	//public static int Enemy4 = 0;
	//public static int Enemy5 = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			if (Enemy1 > 30) {
				TargetObject = ScreenToEnemy.Enemy.transform;
				target = true;
			} else {
				return;
			}

			if (target) {
				GameObject obj = Instantiate (fireObject) as GameObject;
				//obj.transform.LookAt (TargetObject.position);
				obj.transform.position = FirePosition.transform.position;

			}
		}
	}
}
