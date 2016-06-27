using UnityEngine;
using System.Collections;

public class csMissile : MonoBehaviour {
	public Transform target;
	public float Speed = 50.0f;

	public GameObject airExplosionObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FireManager.target) {
			transform.LookAt (FireManager.TargetObject.position);
		} else {
			return;
		}
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);

	}

	void OnCollisionEnter (Collision collision){
		Debug.Log ("Collision Object Name : " + collision.gameObject.name);

		if (collision.gameObject.layer == 8) {
			GameObject particleObj = Instantiate (airExplosionObject) as GameObject;
			particleObj.transform.position = transform.position;
		} 
		Destroy (gameObject);

	}

}
