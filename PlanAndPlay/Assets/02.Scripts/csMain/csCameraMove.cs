using UnityEngine;
using System.Collections;

public class csCameraMove : MonoBehaviour {
	public float Speed;
	public Vector2 nowPos, prePos;
	public Vector3 movePos;

	public Vector2 PreMousePos;

	public static bool bMouseDown;
	Touch touch;
	private float initTouchDist;
	// Use this for initialization
	void Start () {
		initTouchDist = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1)
		{
			Debug.Log ("이동");
			touch = Input.GetTouch (0);
			if(touch.phase == TouchPhase.Began)
			{
				prePos = touch.position - touch.deltaPosition;

				bMouseDown = true;
			}
			else if(touch.phase == TouchPhase.Moved)
			{
				bMouseDown = false;

				nowPos = touch.position - touch.deltaPosition;
				movePos = (Vector3)(prePos - nowPos) * Speed;
				transform.Translate(new Vector3(movePos.x, 0, movePos.y)); 
				prePos = touch.position - touch.deltaPosition;
			}
			else if(touch.phase == TouchPhase.Ended)
			{
			}
			initTouchDist = 0;
		}
		else if(Input.touchCount > 1){
			if (Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position) > initTouchDist) {
				Debug.Log ("확대");
				transform.position -= Vector3.up * 0.2f; 
			} else if (Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position) < initTouchDist) {
				Debug.Log ("축소");
				transform.position += Vector3.up * 0.2f; 
			} else {
				initTouchDist = 0;
			}
			initTouchDist = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);
		}
	}
}
