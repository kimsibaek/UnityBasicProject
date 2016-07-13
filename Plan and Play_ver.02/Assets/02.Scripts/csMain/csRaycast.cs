using UnityEngine;
using System.Collections;

public class csRaycast : MonoBehaviour {
	//private float speed = 5.0f;
	// Use this for initialization
	public Material Mat;
	GameObject obj1;
	GameObject obj2;

	Renderer objRenderer;

	void Start () {
		obj1 = GameObject.Find ("Sight");
		obj2 = GameObject.Find ("prop_switchUnit_screen");
		objRenderer = obj2.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		//float amtMove = speed * Time.deltaTime;
		//float hor = Input.GetAxis ("Horizontal");
		//transform.Translate (Vector3.right * hor * amtMove);

		Debug.DrawRay (transform.position, transform.right * 1, Color.red);

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.right, out hit, 1)) {
			//Debug.Log (hit.collider.gameObject.name);
			//swich on

			obj1.SetActive (false);
			objRenderer.material = Mat;
		}
	}

}