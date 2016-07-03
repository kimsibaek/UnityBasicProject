using UnityEngine;
using System.Collections;

public class csCameraPosition : MonoBehaviour {
	private Vector3 initMousePos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (csMousePoint.TileSelect) {
			transform.position = csMousePoint.Tile.transform.position;
			transform.position -= Vector3.down * 6.0f;
			transform.position += Vector3.forward * 2.0f;
		} 
	}

}
