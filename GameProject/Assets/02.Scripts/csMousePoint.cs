using UnityEngine;
using System.Collections;

public class csMousePoint : MonoBehaviour {
	public static GameObject Tile;
	public LayerMask currentMask;
	public Material Mat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Input.GetButtonDown("Fire1")){
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, currentMask)) {
				Debug.Log (hit.collider.gameObject.name);

				if (hit.transform.tag.Equals ("Tile")) {
					Tile = hit.transform.gameObject;
					Tile.GetComponent<Renderer> ().material = Mat;
				}
			}
		}

	}
}
