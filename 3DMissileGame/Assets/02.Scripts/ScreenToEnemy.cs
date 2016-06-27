using UnityEngine;
using System.Collections;

public class ScreenToEnemy : MonoBehaviour {

	public static GameObject Enemy;

	public LayerMask currentMask;

	bool enemyTarget1 = false;
	bool enemyTarget2 = false;
	bool enemyTarget3 = false;
	bool enemyTarget4 = false;
	bool enemyTarget5 = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, currentMask)){
			//Debug.Log (hit.collider.gameObject.name);
			if (hit.transform.tag.Equals ("Enemy1")) {
				Enemy = hit.transform.gameObject;
				if(enemyTarget1){
					Debug.Log ("Target : " + FireManager.Enemy1);
					FireManager.Enemy1++;
				}
				else if(!enemyTarget1){
					enemyTarget1 = true;
					enemyTarget2 = false;
					enemyTarget3 = false;
					enemyTarget4 = false;
					enemyTarget5 = false;

					FireManager.Enemy1 = 0;

				}
			}
			else if (hit.transform.tag.Equals ("Enemy2")) {
				Enemy = hit.transform.gameObject;
				if(enemyTarget2){
					Debug.Log ("Target : " + FireManager.Enemy1);
					FireManager.Enemy1++;
				}
				else if(!enemyTarget2){
					enemyTarget1 = false;
					enemyTarget2 = true;
					enemyTarget3 = false;
					enemyTarget4 = false;
					enemyTarget5 = false;

					FireManager.Enemy1 = 0;

				}
			}
			else if (hit.transform.tag.Equals ("Enemy3")) {
				Enemy = hit.transform.gameObject;
				if(enemyTarget3){
					Debug.Log ("Target : " + FireManager.Enemy1);
					FireManager.Enemy1++;
				}
				else if(!enemyTarget1){
					enemyTarget1 = false;
					enemyTarget2 = false;
					enemyTarget3 = true;
					enemyTarget4 = false;
					enemyTarget5 = false;

					FireManager.Enemy1 = 0;

				}
			}
			else if (hit.transform.tag.Equals ("Enemy4")) {
				Enemy = hit.transform.gameObject;
				if(enemyTarget4){
					Debug.Log ("Target : " + FireManager.Enemy1);
					FireManager.Enemy1++;
				}
				else if(!enemyTarget4){
					enemyTarget1 = false;
					enemyTarget2 = false;
					enemyTarget3 = false;
					enemyTarget4 = true;
					enemyTarget5 = false;

					FireManager.Enemy1 = 0;

				}
			}
			else if (hit.transform.tag.Equals ("Enemy5")) {
				Enemy = hit.transform.gameObject;
				if(enemyTarget5){
					Debug.Log ("Target : " + FireManager.Enemy1);
					FireManager.Enemy1++;
				}
				else if(!enemyTarget5){
					enemyTarget1 = false;
					enemyTarget2 = false;
					enemyTarget3 = false;
					enemyTarget4 = false;
					enemyTarget5 = true;

					FireManager.Enemy1 = 0;

				}
			}
		}
	}


}
