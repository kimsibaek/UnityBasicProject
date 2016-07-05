using UnityEngine;
using System.Collections;

public class csCameraMove : MonoBehaviour {
	public float Speed;
	public Vector2 nowPos, prePos;
	public Vector3 movePos;

	public Vector2 PreMousePos;

	public static bool bMouseDown;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch (0);
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
				transform.Translate(new Vector3(movePos.x, transform.position.y, movePos.y)); 
				prePos = touch.position - touch.deltaPosition;
			}
			else if(touch.phase == TouchPhase.Ended)
			{
			}
		}
	}
}
