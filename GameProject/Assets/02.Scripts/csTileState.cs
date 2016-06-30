using UnityEngine;
using System.Collections;

public class csTileState : MonoBehaviour {
	public Material Mat;
	public Material Mat2;

	public bool state;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(!csMousePoint.Tile || csMousePoint.touchTile){
			return;
		}

		if (csMousePoint.Tile.transform == transform) {
			Debug.Log ("select");
			transform.GetComponent<Renderer> ().material = Mat;
		} else {
			transform.GetComponent<Renderer> ().material = Mat2;
		}
		*/
	}
}
