using UnityEngine;
using System.Collections;

public class circular_animate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().material.SetFloat("_Amount", (Mathf.Sin(Time.time) + 1) * 0.5f);
	}
}
