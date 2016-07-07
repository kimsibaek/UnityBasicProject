using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class csTouchPointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public static bool b_checkpos; 
	// Use this for initialization
	void Start () {
		b_checkpos = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerDown(PointerEventData eventData){
		Debug.Log ("ddd");
		//false
		b_checkpos = false;
	}
	public void OnPointerUp(PointerEventData eventData){
		//true
		b_checkpos = true;
	}
}
